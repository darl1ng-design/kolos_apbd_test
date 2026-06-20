using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos_Test.entities;

[Table("Students")]
public class Students
{
    [Key]
    public int StudentId { get; set; }

    [MaxLength(100)] public string FirstName { get; set; } = null!;
    [MaxLength(100)] public string LastName { get; set; } = null!;
    [MaxLength(100)] public string Email { get; set; } = null!;
    public int EnrollmentYear{ get; set; }

    public ICollection<Enrollments> Enrollments { get; set; } = null!;
}