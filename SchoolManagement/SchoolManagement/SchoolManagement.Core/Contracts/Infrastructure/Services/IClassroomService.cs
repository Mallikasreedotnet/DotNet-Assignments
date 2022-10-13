using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IClassroomService
    {
        Task<Classroom> CreateClassroomAsync(Classroom classroom);
        Task<Classroom> DeleteAsync(int classroomId);
        Task<IEnumerable<ClassroomDto>> GetClassroomAsync();
        Task<Classroom> GetClassroomByIdAsync(int classroomId);
        Task<ClassroomDto> GetClassroomAsync(int classroomId);
        Task<Classroom> UpdateClassroomAsync(int classroomId, Classroom classroom);
        Task<int> GetClassroomWithStudentByCountAsync(int classroomId);
        Task<IEnumerable<ClassroomDetailsDto>> GetClassroomWithStudentDetails(int classroomId);
        Task<Classroom> GetTeacherwithGrade(int gradeId, int teacherId, string section);
    }
}