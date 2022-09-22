using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class ClassroomStudentService : IClassroomStudentService
    {
        private readonly IClassroomStudentRepository _classroomStudentRepository;
        public ClassroomStudentService(IClassroomStudentRepository classroomStudentRepository)
        {
            _classroomStudentRepository = classroomStudentRepository;
        }

        public async Task<IEnumerable<ClassroomStudent>> GetClassroomStudentAsync()
        {
            return await _classroomStudentRepository.GetClassroomStudentAsync();
        }

        public async Task<ClassroomStudent> GetClassroomStudentAsync(int classroomStudentId)
        {
            return await _classroomStudentRepository.GetClassroomStudentAsync(classroomStudentId);
        }

        public async Task<ClassroomStudent> CreateClassroomStudentAsync(ClassroomStudent classroomStudent)
        {
            return await _classroomStudentRepository.CreateClassroomStudentAsync(classroomStudent);
        }
        public async Task<ClassroomStudent> UpdateClassroomStudentAsync(int classroomStudentId, ClassroomStudent classroomStudent)
        {
            var classroomStudentToBeUpdated = await GetClassroomStudentAsync(classroomStudentId);
            classroomStudentToBeUpdated.ClassroomId = classroomStudent.ClassroomId;
            classroomStudentToBeUpdated.StudentId = classroomStudent.StudentId;
            var data = await _classroomStudentRepository.UpdateClassroomStudentAsync(classroomStudentToBeUpdated);
            return data;
        }

        public async Task<ClassroomStudent> DeleteAsync(int classroomStudentId)
        {
            return await _classroomStudentRepository.DeleteAsync(classroomStudentId);
        }

        public async Task<ClassroomStudent> GetNotRepeatedData(int classroomId, int studentId)
        {
            return await _classroomStudentRepository.GetNotRepeatedData(classroomId, studentId);
        }
    }
}
