using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos_Test.entities;

[Table("Departments")]
public class Departments
{
    [Key]
    public int DepartmentId {get; set;}

    [MaxLength(100)] public string Name { get; set; } = null!;
    [MaxLength(100)] public string FacultyBuilding { get; set; } = null!;
    [Column(TypeName = "numeric")]
    [Precision(10, 2)]
    public double Budget { get; set; }
    public ICollection<Professors> Professors { get; set; } = null!;
}   