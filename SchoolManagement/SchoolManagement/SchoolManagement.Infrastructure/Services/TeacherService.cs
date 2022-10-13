using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository repository)
        {
            _teacherRepository = repository;
        }

        public async Task<IEnumerable<TeacherDto>> GetTeacherAsync()
        {
            return await _teacherRepository.GetTeacherAsync();
        }

        public async Task<TeacherDto> GetTeacherAsync(int teacherId)
        {
            return await _teacherRepository.GetTeacherAsync(teacherId);
        }

        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            return await _teacherRepository.GetTeacherByIdAsync(teacherId);
        }

        public async Task<ClassroomTeacherDto> GetTeacherWithClass(int teacherId)
        {
           return await _teacherRepository.GetTeacherWithClass(teacherId);
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            return await _teacherRepository.CreateTeacherAsync(teacher);
        }

        public async Task<Teacher> UpdateAsync(int teacherId, Teacher teacher)
        {
            var updatedToBeTeacher = await GetTeacherByIdAsync(teacherId);
            updatedToBeTeacher.Email = teacher.Email;
            updatedToBeTeacher.Password = teacher.Password;
            updatedToBeTeacher.Fname = teacher.Fname;
            updatedToBeTeacher.Lname = teacher.Lname;
            updatedToBeTeacher.Dob = teacher.Dob;
            updatedToBeTeacher.Phone = teacher.Phone;
            updatedToBeTeacher.Mobile = teacher.Mobile;
            updatedToBeTeacher.Status = teacher.Status;
            updatedToBeTeacher.LastLoginDate = teacher.LastLoginDate;
            updatedToBeTeacher.LastLoginIp = teacher.LastLoginIp;
            var data = await _teacherRepository.UpdateAsync(updatedToBeTeacher);
            return data;
        }

        public async Task<Teacher> DeleteAsync(int teacherId)
        {
            return await _teacherRepository.DeleteAsync(teacherId);
        }
    }
}
