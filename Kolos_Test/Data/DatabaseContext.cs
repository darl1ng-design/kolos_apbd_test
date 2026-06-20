using Kolos_Test.entities;
using Microsoft.EntityFrameworkCore;

namespace Kolos_Test.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Courses> Courses { get; set; }
    public DbSet<Departments> Departments { get; set; }
    public DbSet<Enrollments> Enrollments { get; set; }
    public DbSet<Professors> Professors { get; set; }
    public DbSet<Students> Students { get; set; }
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Courses>().HasData(new List<Courses>()
        {
            new Courses() { CourseId = 1, Title = "Kurs dla cweli v1", ProfessorId = 1, Credits = 283, Semester = 1 },
            new Courses() { CourseId = 2, Title = "Kurs dla cweli v2", ProfessorId = 2, Credits = 100, Semester = 4 },
        });
        
     
        modelBuilder.Entity<Professors>().HasData(new List<Professors>()
        {
            new Professors() {ProfessorId = 1, DepartmentId = 1, Email = "jestemcwelem@gmail.com", FirstName = "ss", LastName = "dsdsd"},
            new Professors() {ProfessorId = 2, DepartmentId = 2, Email = "jestemcwelem235@gmail.com", FirstName = "fdff", LastName = "dfsfds"}
        });

        modelBuilder.Entity<Enrollments>().HasData(new List<Enrollments>()
        {
            new Enrollments() {CourseId = 1, StudentId = 1, Grade = 5.3, Status = "chujnia"},
            new Enrollments() {CourseId = 2, StudentId = 2, Grade = 1.3, Status = "cyka nahui"}
        });

        modelBuilder.Entity<Departments>().HasData(new List<Departments>()
        {
           new Departments() {DepartmentId = 1, FacultyBuilding = "budynek dla cweli", Name = "Kurs dla cweli v1", Budget = 1999.2},
           new Departments() {DepartmentId = 2, FacultyBuilding = "budynek dla cweli v2", Name = "Kurs dla cweli v2", Budget = 3299.2},
        });

        modelBuilder.Entity<Students>().HasData(new List<Students>()
        {
           new Students() {StudentId = 1, FirstName = "cwel", LastName = "cwelisko", Email = "Cwelisko@chuj.pl", EnrollmentId = 1},
           new Students() {StudentId = 2, FirstName = "pedal", LastName = "pedalski", Email = "pedal@cwel.pl", EnrollmentId = 2}
        });

    }
}