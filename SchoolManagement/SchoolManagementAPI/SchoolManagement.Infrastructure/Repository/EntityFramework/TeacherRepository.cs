using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;
        public TeacherRepository()
        {
            _schoolManagementDbContext =new SchoolManagementDbContext();
        }
        public async Task<IEnumerable<Teacher>> GetTeacherAsync()
        {
            var teacherData=await(from teacher in _schoolManagementDbContext.Teachers
                            select teacher).ToListAsync();  
            return teacherData;
        }

        public async Task<Teacher> GetTeacherAsync(int teacherId)
        {
            return await _schoolManagementDbContext.Teachers.FindAsync(teacherId);
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
                TeacherId = teacher.TeacherId
            };
            _schoolManagementDbContext.Teachers.Add(teacherData);
            await _schoolManagementDbContext.SaveChangesAsync();
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
            _schoolManagementDbContext.Teachers.Update(updatedToBeTeacher);
            await _schoolManagementDbContext.SaveChangesAsync();
            return updatedToBeTeacher;
        }

        public async Task<Teacher> DeleteAsync(int teacherId)
        {
            var deletedToBeTeacher= await GetTeacherAsync(teacherId);
            _schoolManagementDbContext.Teachers.Remove(deletedToBeTeacher);
            await _schoolManagementDbContext.SaveChangesAsync();
            return deletedToBeTeacher;
        }
    }
}
