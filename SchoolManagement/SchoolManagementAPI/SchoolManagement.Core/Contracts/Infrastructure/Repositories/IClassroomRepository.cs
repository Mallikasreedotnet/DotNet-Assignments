using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<Classroom>> GetClassroomAsync();
        Task<Classroom> GetClassroomAsync(int classroomId);
        Task<Classroom> CreateClassroomAsync(Classroom classroom);
        Task<Classroom> UpdateClassroomAsync(int classroomId, Classroom classroom);
        Task<Classroom> DeleteAsync(int classroomId);
    }
}
