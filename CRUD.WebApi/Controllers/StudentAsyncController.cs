using CRUD.Business;
using CRUD.Business.Contracts;
using CRUD.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAsyncController : ControllerBase
    {
        private readonly IStudentAsyncManager studentManager;

        public StudentAsyncController(IStudentAsyncManager studentManager)
        {
            this.studentManager = studentManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await studentManager.GetAllStudents();
                if (students == null)
                {
                    return NotFound("No students found");
                }
                return Ok(students);

            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching the products contact admin");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            try
            {
                var delStudent = await studentManager.DeleteStudent(id);
                if (delStudent == null)
                {
                    return NotFound("No Product Found");
                }
                return Ok(delStudent);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting the students contact admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentVM Student)
        {
            try
            {
                if (Student == null)
                {
                    return BadRequest("No Student Passed");
                }
                Common.Models.Student student = new Common.Models.Student()
                {
                    StudentId = Student.StudentId,
                    StudentName = Student.StudentName,
                    ContactNumber = Student.ContactNumber,
                    StudentDiv = Student.StudentDiv,
                    StudentEmail = Student.StudentEmail,
                    Address = new Common.Models.StudentAddress
                    {
                        AddressId = Student.Address.AddressId,
                        City = Student.Address.City,
                        Pincode = Student.Address.Pincode,
                        state = Student.Address.state,
                        Streetname = Student.Address.Streetname
                    }
                };
                var resultStudent = await studentManager.CreateStudent(student);
                if (resultStudent == null)
                {
                    return BadRequest("unable to add the student");
                }
                //1. status code 201
                //2. newly created object 
                //3. location in header of newaly created object

                return CreatedAtAction(nameof(GetStudentById), new { id = resultStudent.StudentId }, resultStudent);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the student contact admin");
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentVM Student)
        {
            try
            {
                if (Student == null)
                {
                    return BadRequest("No student passed");

                }
                Common.Models.Student student = new Common.Models.Student()
                {
                    StudentId = Student.StudentId,
                    StudentName = Student.StudentName,
                    ContactNumber = Student.ContactNumber,
                    StudentDiv = Student.StudentDiv,
                    StudentEmail = Student.StudentEmail,
                    Address = new Common.Models.StudentAddress
                    {
                        AddressId = Student.Address.AddressId,
                        City = Student.Address.City,
                        Pincode = Student.Address.Pincode,
                        state = Student.Address.state,
                        Streetname = Student.Address.Streetname,
                    }
                };
                var updatedStudent = await studentManager.UpdateStudent(student);
                if (updatedStudent == null)
                {
                    return BadRequest("Student not updated");
                }
                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating the products contact admin");
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await studentManager.GetStudentById(id);
                if(student == null)
                {
                    return BadRequest("Error while fetching the students");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting the student contact admin");
            }
        }
    }
}
