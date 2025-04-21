using CRUD.Common.Models;

namespace CRUD.WebApi.Models
{
    public class StudentVM
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string StudentEmail { get; set; } = string.Empty;

        public string StudentDiv { get; set; } = string.Empty;

        public int ContactNumber { get; set; }
        public StudentAddress Address { get; set; }

    }
}
