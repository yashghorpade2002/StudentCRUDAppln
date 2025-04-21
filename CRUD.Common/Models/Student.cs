namespace CRUD.Common.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string StudentEmail { get; set; } = string.Empty;

        public string StudentDiv { get; set; } = string.Empty;

        public int ContactNumber { get; set; }

        private List<Subject> subjects = new List<Subject>();
        public StudentAddress Address { get; set; }

        public IEnumerable<Subject> GetSubjects() => subjects;

        public void AddSubjects(Subject subject) => subjects.Add(subject);
    }
}
