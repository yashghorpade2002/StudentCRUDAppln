using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.EF.Models
{

    [Table("subject")]
    internal class Subject
    {
        [Key]
        [Column("subjectId")]
        public int SubjectId { get; set; }

        [Column("subjectName")]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string SubjectName { get; set; } = string.Empty;

        [Column("Description")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        public int StudentId { get; set; } // Navigation Property

        public Student Student { get; set; }
    }
}