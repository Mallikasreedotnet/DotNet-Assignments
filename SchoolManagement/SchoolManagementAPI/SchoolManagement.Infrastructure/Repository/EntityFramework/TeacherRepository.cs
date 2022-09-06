using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public TeacherRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Teacher>> GetTeacherAsync()
        {
            var query = "select * from Teacher";
            var teacherData = await _dbconnection.QueryAsync<Teacher>(query);
            return teacherData;
        }

        public async Task<Teacher> GetTeacherAsync(int teacherId)
        {
            var query = "Select * from Teacher where Teacher_id=@TeacherId";
            return (await _dbconnection.QueryAsync<Teacher>(query, new { teacherId })).FirstOrDefault();
            //return (await _dbconnection.QueryFirstAsync<Teacher>(query, new { teacherId = teacherId }));
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            var teacherData = new Teacher()
            {
                Dob = teacher.Dob,
                Email = teacher.Email,
                Fname = teacher.Fname,
                LastLoginDate = teacher.LastLoginDate,
                LastLoginIp = teacher.LastLoginIp,
                Lname = teacher.Lname,
                Mobile = teacher.Mobile,
                Password = teacher.Password,
                Phone = teacher.Phone,
                Status = teacher.Status,
                Teacher_id = teacher.Teacher_id
            };
            _schoolDbContext.Teachers.Add(teacherData);
            await _schoolDbContext.SaveChangesAsync();
            return teacherData;
        }

        public async Task<Teacher> UpdateAsync(int teacherId,Teacher teacher)
        {
            var updatedToBeTeacher=await GetTeacherAsync(teacherId);
            updatedToBeTeacher.Email = teacher.Email;
            updatedToBeTeacher.Password = teacher.Password;
            updatedToBeTeacher.Fname = teacher.Fname;
            updatedToBeTeacher.Lname = teacher.Lname;
            updatedToBeTeacher.Dob=teacher.Dob;
            updatedToBeTeacher.Phone = teacher.Phone;
            updatedToBeTeacher.Mobile = teacher.Mobile;
            updatedToBeTeacher.Status = teacher.Status; 
            updatedToBeTeacher.LastLoginDate = teacher.LastLoginDate;
            updatedToBeTeacher.LastLoginIp = teacher.LastLoginIp;
            _schoolDbContext.Teachers.Update(updatedToBeTeacher);
            await _schoolDbContext.SaveChangesAsync();
            return updatedToBeTeacher;
        }

        public async Task<Teacher> DeleteAsync(int teacherId)
        {
            var deletedToBeTeacher= await GetTeacherAsync(teacherId);
            _schoolDbContext.Teachers.Remove(deletedToBeTeacher);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeTeacher;
        }
    }
}
