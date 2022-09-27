using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherDto>> GetTeacherAsync();
        Task<TeacherDto> GetTeacherAsync(int teacherId);
        Task<Teacher> GetTeacherByIdAsync(int teacherId);
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateAsync(Teacher teacher);
        Task<Teacher> DeleteAsync(int teacherId);
        Task<ClassroomTeacherDto> GetTeacherWithClass(int teacherId);
    }
}
