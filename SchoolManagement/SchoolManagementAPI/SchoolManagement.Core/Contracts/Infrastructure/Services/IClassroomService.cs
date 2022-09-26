using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IClassroomService
    {
        Task<Classroom> CreateClassroomAsync(Classroom classroom);
        Task<Classroom> DeleteAsync(int classroomId);
        Task<IEnumerable<Classroom>> GetClassroomAsync();
        Task<Classroom> GetClassroomAsync(int classroomId);
        Task<Classroom> UpdateClassroomAsync(int classroomId, Classroom classroom);
        Task<int> GetClassroomWithStudentByCountAsync(int classroomId);
        Task<IEnumerable<ClassroomDetailsDto>> GetClassroomWithStudentDetails(int classroomId);
        Task<Classroom> GetTeacherwithGrade(int gradeId, int teacherId, string section);
    }
}