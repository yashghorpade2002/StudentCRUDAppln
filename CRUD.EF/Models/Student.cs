using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.EF.Models
{
    [Table("student")]
    internal class Student
    {
        [Key]
        [Column("studentId")]
        public int StudentId { get; set; }

        [Column("studentName")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string StudentName { get; set; } = string.Empty;

        [Column("studentEmail")]
        [DataType(DataType.Text)]
        [MaxLength(40)]
        public string StudentEmail { get; set; } = string.Empty;

        [Column("studentDiv")]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string StudentDiv { get; set; } = string.Empty;

        [Column("contactNumber")]
        public int ContactNumber { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        private List<Subject> subjects = new List<Subject>();

        public StudentAddress Address { get; set; }

        public IEnumerable<Subject> GetSubjects() => subjects;

        public void AddSubjects(Subject subject) => subjects.Add(subject);
    }
}
