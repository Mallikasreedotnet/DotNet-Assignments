using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetTeacherAsync();
        Task<TeacherDto> GetTeacherAsync(int teacherId);
        Task<Teacher> GetTeacherByIdAsync(int teacherId);
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateAsync(int teacherId, Teacher teacher);
        Task<Teacher> DeleteAsync(int teacherId);
        Task<ClassroomTeacherDto> GetTeacherWithClass(int teacherId);
    }
}
