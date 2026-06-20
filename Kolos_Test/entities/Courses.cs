using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos_Test.entities;

[Table("Courses")]
public class Courses
{
    [Key] public int CourseId { get; set; }

    [MaxLength(100)] public string Title { get; set; } = null!;

    public int Credits { get; set; }

    public int Semester { get; set; }

    [ForeignKey(nameof(Professors))] public int ProfessorId { get; set; }

    public Professors Professors { get; set; } = null!;

    public ICollection<Enrollments> Enrollments { get; set; } = null!;
}