namespace Kolos_Test.dto;

public class GetProfessorInfoDTO
{
    public int professorId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public List<CoursesDTO> courses { get; set; }
}

public class CoursesDTO
{
    public int courseId { get; set; }
    public string title { get; set; }
    public int credits { get; set; }
    public int semester { get; set; }
    public List<EnrollmentsDTO> enrollments { get; set; }
}

public class EnrollmentsDTO
{
    public double grade { get; set; }
    public string status { get; set; }
    public StudentDTO student { get; set; }
}

public class StudentDTO
{
    public int studentId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public int enrollmentYear { get; set; }
}