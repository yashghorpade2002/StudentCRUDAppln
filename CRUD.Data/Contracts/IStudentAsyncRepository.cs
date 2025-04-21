using CRUD.Common.Models;

namespace CRUD.Data.Contracts
{
    public interface IStudentAsyncRepository
    {
        /// <summary>
        /// Method to add student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Newaly added student</returns>
        public Task<Student> CreateStudent(Student student);

        /// <summary>
        /// Method to update the student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Updated student</returns>
        public Task<Student> UpdateStudent(Student student);

        /// <summary>
        /// Method to delete the student 
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Deleted student</returns>
        public Task<Student> DeleteStudent(int id);
        
        /// <summary>
        /// method to get all the students
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Student>> GetAllStudents();

        /// <summary>
        /// Method to get a student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Student> GetStudentById(int id);
    }
}
