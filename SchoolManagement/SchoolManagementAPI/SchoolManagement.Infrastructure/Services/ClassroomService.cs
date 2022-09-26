using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<IEnumerable<Classroom>> GetClassroomAsync()
        {
            return await _classroomRepository.GetClassroomAsync();
        }

        public async Task<Classroom> GetClassroomAsync(int classroomId)
        {
            return await _classroomRepository.GetClassroomAsync(classroomId);
        }

        public async Task<Classroom> CreateClassroomAsync(Classroom classroom)
        {
            return await _classroomRepository.CreateClassroomAsync(classroom);
        }
        public async Task<Classroom> UpdateClassroomAsync(int classroomId, Classroom classroom)
        {
            var classroomToBeUpdated = await GetClassroomAsync(classroomId);
            classroomToBeUpdated.Section = classroom.Section;
            classroomToBeUpdated.TeacherId = classroom.TeacherId;
            classroomToBeUpdated.Status = classroom.Status;
            classroomToBeUpdated.GradeId = classroom.GradeId;
            classroomToBeUpdated.Year = classroom.Year;
            classroomToBeUpdated.Remarks = classroom.Remarks;
            var data = await _classroomRepository.UpdateClassroomAsync(classroomToBeUpdated);
            return data;
        }

        public async Task<Classroom> DeleteAsync(int classroomId)
        {
            return await _classroomRepository.DeleteAsync(classroomId);
        }

        public async Task<int> GetClassroomWithStudentByCountAsync(int classroomId)
        {
            return await _classroomRepository.GetClassroomWithStudentByCountAsync(classroomId);
        }

        public async Task<IEnumerable<ClassroomDetailsDto>> GetClassroomWithStudentDetails(int classroomId)
        {
            return await _classroomRepository.GetClassroomWithStudentDetails(classroomId);
        }

        public async Task<Classroom> GetTeacherwithGrade(int gradeId, int teacherId, string section)
        {
            return await _classroomRepository.GetTeacherwithGrade(gradeId, teacherId, section);
        }
    }
}
