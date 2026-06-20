namespace Kolos_Test.dto;

public class CreateCourseDTO
{
    public string professorsLastName { get; set; }
    public string title { get; set; }
    public int credits { get; set; }
    public int semester { get; set; }
    public List<int> students { get; set; }
}
