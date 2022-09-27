using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ClassroomStudentRepository : IClassroomStudentRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public ClassroomStudentRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<ClassroomStudentDto>> GetClassroomStudentAsync()
        {
            var query = "execute spGetClassroomStudent";
            var classroomData = await _dbconnection.QueryAsync<ClassroomStudentDto>(query);
            return classroomData;
        }

        public async Task<ClassroomStudentDto> GetClassroomStudentAsync(int classroomStudentId)
        {
            var query = "execute spGetClassroomStudentId @ClassroomStudentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ClassroomStudentDto>(query, new { classroomStudentId }));
        }

        public async Task<ClassroomStudent> GetClassroomStudentByIdAsync(int classroomStudentId)
        {
            var query = "select * from ClassroomStudent where ClassroomStudentId=@ClassroomStudentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ClassroomStudent>(query, new { classroomStudentId }));
        }

        public async Task<ClassroomStudent> CreateClassroomStudentAsync(ClassroomStudent classroomStudent)
        {
            _schoolDbContext.ClassroomStudents.Add(classroomStudent);
            await _schoolDbContext.SaveChangesAsync();
            return classroomStudent;
        }

        public async Task<ClassroomStudent> UpdateClassroomStudentAsync(ClassroomStudent classroomStudent)
        {
            _schoolDbContext.ClassroomStudents.Update(classroomStudent);
            await _schoolDbContext.SaveChangesAsync();
            return classroomStudent;
        }

        public async Task<ClassroomStudent> DeleteAsync(int classroomStudentId)
        {
            var deletedToBeClassroomStudent = await GetClassroomStudentByIdAsync(classroomStudentId);
            _schoolDbContext.ClassroomStudents.Remove(deletedToBeClassroomStudent);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeClassroomStudent;
        }

        public async Task<ClassroomStudent> GetNotRepeatedData(int classroomId,int studentId)
        {
            var data = "Select * from ClassroomStudent where classroomId=@classroomId and studentId=@studentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ClassroomStudent>(data, new { classroomId, studentId }));
        }
    }
}
