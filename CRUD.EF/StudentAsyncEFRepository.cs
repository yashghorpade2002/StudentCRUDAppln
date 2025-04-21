using CRUD.Common.Models;
using CRUD.Data.Contracts;
using CRUD.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EF
{
    public class StudentAsyncEFRepository : IStudentAsyncRepository
    {
        private CrudDbContext context;

        public StudentAsyncEFRepository()
        {
            context = new CrudDbContext();
        }
        public async Task<Common.Models.Student> CreateStudent(Common.Models.Student student)
        {
            try
            {
                if(student != null)
                {
                    Models.Student dbStudent = new Models.Student();
                    MapToDb(student, dbStudent);
                    dbStudent.IsDeleted = false;
                    var result = await context.Students.AddAsync(dbStudent);
                    context.SaveChanges();
                    return await GetStudentById(result.Entity.StudentId);
                }

            } catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public async Task<Common.Models.Student> GetStudentById(int studentId)
        {
            try
            {
                var dbStudent = await context.Students
                                       .Include(x => x.Address)
                                       .Where(x => x.IsDeleted == false && x.StudentId == studentId)
                                       .FirstOrDefaultAsync();
                if(dbStudent != null)
                {
                    Common.Models.Student student = new Common.Models.Student();
                    MapToEntity(dbStudent, student);
                    return student;
                }

            } catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public async Task<Common.Models.Student> DeleteStudent(int id)
        {
            try
            {
                var dbStudent = await context.Students
                                        .Include(x => x.Address)
                                        .Where(x => x.IsDeleted == false && x.StudentId == id)
                                        .FirstOrDefaultAsync();

                if(dbStudent != null)
                {
                    dbStudent.IsDeleted = true;
                    await context.SaveChangesAsync();
                    Common.Models.Student student1 = new Common.Models.Student();
                    MapToEntity(dbStudent, student1);
                    return student1;
                }

            } catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public async Task<IEnumerable<Common.Models.Student>> GetAllStudents()
        {
            try
            {
                var dbStudents = await context.Students
                                            .Include(x => x.Address)
                                            .Where(x => x.IsDeleted == false)
                                            .ToListAsync();
                if(dbStudents.Count > 0)
                {
                    List<Common.Models.Student> students = new List<Common.Models.Student> ();
                    foreach (var dbStudent in dbStudents)
                    {
                        Common.Models.Student student = new Common.Models.Student();
                        MapToEntity(dbStudent, student);
                        students.Add(student);
                    }
                    return students;
                }

            }catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public async Task<Common.Models.Student> UpdateStudent(Common.Models.Student student)
        {
            try
            {
                var dbStudent = await context.Students
                                       .Include(x => x.Address)
                                       .Where(x => x.IsDeleted == false && x.StudentId == student.StudentId)
                                       .FirstOrDefaultAsync();
                if(dbStudent != null)
                {
                    student.Address.AddressId = dbStudent.Address.AddressId;
                    MapToDb(student, dbStudent);
                    await context.SaveChangesAsync();
                    return student;
                }

            } catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        #region Private methods

        private void MapToDb(Common.Models.Student student, Models.Student dbStudent)
        {
            dbStudent.StudentId = student.StudentId;
            dbStudent.StudentName = student.StudentName;
            dbStudent.StudentDiv = student.StudentDiv;
            dbStudent.ContactNumber = student.ContactNumber;
            dbStudent.StudentEmail = student.StudentEmail;
            dbStudent.Address = new Models.StudentAddress
            {
                AddressId = student.Address.AddressId,
                City = student.Address.City,
                Pincode = student.Address.Pincode,
                Streetname = student.Address.Streetname,
                state = student.Address.state
            };

        }

        private void MapToEntity(Models.Student dbStudent, Common.Models.Student student)
        {


            student.StudentId = dbStudent.StudentId;
            student.StudentName = dbStudent.StudentName;
            student.ContactNumber = dbStudent.ContactNumber;
            student.StudentDiv = dbStudent.StudentDiv;
            student.StudentEmail = dbStudent.StudentEmail;
            student.Address = new Common.Models.StudentAddress
            {
                AddressId = dbStudent.Address.AddressId,
                City = dbStudent.Address.City,
                Pincode = dbStudent.Address.Pincode,
                state = dbStudent.Address.state,
                Streetname = dbStudent.Address.Streetname
            };
            
        }

        #endregion
    }
}
