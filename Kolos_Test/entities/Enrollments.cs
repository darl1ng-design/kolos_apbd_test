using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos_Test.entities;


[Table("Enrollments")]
[PrimaryKey(nameof(CourseId), nameof(StudentId))]
public class Enrollments
{

    [ForeignKey(nameof(Courses))] public int CourseId { get; set; }

    [ForeignKey(nameof(Students))] public int StudentId { get; set; }

    [Column(TypeName = "numeric")]
    [Precision(2, 1)]
    public double? Grade { get; set; }

    [MaxLength(100)]
    public string Status { get; set; } = null!;

    public Courses Courses { get; set; } = null !;
    public Students Students { get; set; } = null!;
}