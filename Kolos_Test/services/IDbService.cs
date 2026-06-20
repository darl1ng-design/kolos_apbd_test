using Kolos_Test.dto;

namespace Kolos_Test.services;

public interface IDbService
{
    public Task<GetProfessorInfoDTO>  GetProfessorInfo(string lastName);
    public Task createCourse(CreateCourseDTO dto);
}