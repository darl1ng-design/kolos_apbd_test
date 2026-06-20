using Kolos_Test.Data;
using Kolos_Test.dto;
using Kolos_Test.entities;
using Kolos_Test.exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Kolos_Test.services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetProfessorInfoDTO> GetProfessorInfo(string? lastName)
    {
        if (lastName == null || lastName.IsNullOrEmpty())
            throw new InvalidArgumentException("Invalid argument passed");
        
        var professorInfo = await _context.Professors
            .Where(p => p.LastName == lastName)
            .Select(p => new GetProfessorInfoDTO()
            {
                professorId = p.ProfessorId,
                firstName = p.FirstName,
                lastName = p.LastName,
                email = p.Email,
                name = p.Departments.Name,
                courses = p.Courses
                    .Select(c => new CoursesDTO()
                    {
                        courseId = c.CourseId,
                        title = c.Title,
                        credits = c.Credits,
                        semester = c.Semester,
                        enrollments = c.Enrollments
                            .Select(e => new EnrollmentsDTO()
                            {
                                grade = e.Grade,
                                status = e.Status,
                                student = new StudentDTO()
                                {
                                    studentId = e.Students.StudentId,
                                    firstName = e.Students.FirstName,
                                    lastName = e.Students.LastName,
                                    email = e.Students.Email,
                                    enrollmentYear = e.Students.EnrollmentYear
                                }
                            }).ToList()
                    }).ToList()
            }).FirstOrDefaultAsync();

        if (professorInfo is null)
            throw new NotFoundException("Professor not found");

        return professorInfo;
    }

    public async Task createCourse(CreateCourseDTO dto)
    {
        if(dto.professorsLastName.IsNullOrEmpty())
            throw new InvalidArgumentException("Invalid argument passed. Last name of professor cant be null or empty");
        
        if(dto.title.IsNullOrEmpty())
            throw new InvalidArgumentException("Invalid argument passed. TItle dcant be null or empty.");
        
        if(dto.students.IsNullOrEmpty() || dto.students.Count == 0)
            throw new InvalidArgumentException("Invalid argument passed. Students are empty.");
        
        await using var transaction = await _context.Database.BeginTransactionAsync();

        var professor = _context.Professors
            .Where(p => p.LastName == dto.professorsLastName);
        
        if(professor is null)
            throw new NotFoundException("Professor not found");

        var distinctIds = dto.students.Distinct().ToList();

        var existingStudentsWithId = await _context.Students
            .Where(s => distinctIds.Contains(s.StudentId))
            .Select(s => s.StudentId)
            .ToListAsync();
        
        var missingIds = distinctIds.Except(existingStudentsWithId).ToList();

        if (missingIds.Count > 0)
            throw new NotFoundException("students not found with ids:" + missingIds);


        var course = new Courses()
        {
            Title = dto.title,
            Credits = dto.credits,
            Semester = dto.semester,
            ProfessorId = professor.FirstOrDefault().ProfessorId
        };
        await _context.Courses.AddAsync(course);
        
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}