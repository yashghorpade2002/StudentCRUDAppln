using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.EF.Models
{
    [Table("studentAddress")]
    internal class StudentAddress
    {
        [Key]
        [Column("addressId")]
        public int AddressId { get; set; }

        [Column("streetname")]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string Streetname { get; set; } = string.Empty;

        [Column("city")]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string City { get; set; } = string.Empty;

        [Column("state")]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string state { get; set; } = string.Empty;

        [Column("pinCode")]
        public int Pincode { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        public int StudentId { get; set; } // Navigation property

        public Student Student { get; set; }
    }
}