using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeacherAsync();
        Task<Teacher> GetTeacherAsync(int teacherId);
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateAsync(int teacherId, Teacher teacher);
        Task<Teacher> DeleteAsync(int teacherId);
        Task<ClassroomDto> GetTeacherWithClass(int teacherId);
    }
}
