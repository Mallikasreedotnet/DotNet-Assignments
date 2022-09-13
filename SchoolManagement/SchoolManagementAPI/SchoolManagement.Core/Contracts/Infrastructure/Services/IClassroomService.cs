using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IClassroomService
    {
        Task<IEnumerable<Classroom>> GetClassroomAsync();
        Task<Classroom> GetClassroomAsync(int classroomId);
        Task<Classroom> CreateClassroomAsync(Classroom classroom);
        Task<Classroom> UpdateClassroomAsync(int classroomId, Classroom classroom);
        Task<Classroom> DeleteAsync(int classroomId);
    }
}
