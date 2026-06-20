using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos_Test.entities;


[Table("Professors")]
public class Professors
{
    [Key]
    public int ProfessorId { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    
    [MaxLength(100)]
    public string Email { get; set; } = null!;
    
    
    [ForeignKey(nameof(Departments))]
    public int DepartmentId { get; set; }
    
    public Departments Departments { get; set; } = null!;

    public ICollection<Courses> Courses { get; set; } = null!;
}