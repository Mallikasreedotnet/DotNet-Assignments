using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<ClassroomDto>> GetClassroomAsync();
        Task<ClassroomDto> GetClassroomAsync(int classroomId);
        Task<Classroom> GetClassroomByIdAsync(int classroomId);
        Task<Classroom> CreateClassroomAsync(Classroom classroom);
        Task<Classroom> UpdateClassroomAsync(Classroom classroom);
        Task<Classroom> DeleteAsync(int classroomId);
        Task<int> GetClassroomWithStudentByCountAsync(int classroomId);
        Task<IEnumerable<ClassroomDetailsDto>> GetClassroomWithStudentDetails(int classroomId);
        Task<Classroom> GetTeacherwithGrade(int gradeId, int teacherId, string section);
    }
}
