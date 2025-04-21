using CRUD.Business.Contracts;
using CRUD.Common.Models;
using CRUD.Data.Contracts;

namespace CRUD.Business
{
    public class StudentAsyncManager : IStudentAsyncManager
    {
        private readonly IStudentAsyncRepository studentRepository;

        public StudentAsyncManager(IStudentAsyncRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public Task<Student> CreateStudent(Student student)
            => studentRepository.CreateStudent(student);

        public Task<Student> DeleteStudent(int id)
            => studentRepository.DeleteStudent(id);

        public Task<IEnumerable<Student>> GetAllStudents()
            => studentRepository.GetAllStudents();

        public Task<Student> GetStudentById(int id)
            => studentRepository.GetStudentById(id);

        public Task<Student> UpdateStudent(Student student)
            => studentRepository.UpdateStudent(student);
    }
}
