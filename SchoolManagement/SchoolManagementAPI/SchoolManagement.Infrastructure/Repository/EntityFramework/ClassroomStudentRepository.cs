using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
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

        public async Task<IEnumerable<ClassroomStudent>> GetClassroomStudentAsync()
        {
            var query = "select * from ClassroomStudent";
            var classroomData = await _dbconnection.QueryAsync<ClassroomStudent>(query);
            return classroomData;
        }

        public async Task<ClassroomStudent> GetClassroomStudentAsync(int classroomStudentId)
        {
            var query = "select * from where ClassroomStudentId=@ClassroomStudentId";
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
            var deletedToBeClassroomStudent = await GetClassroomStudentAsync(classroomStudentId);
            _schoolDbContext.ClassroomStudents.Remove(deletedToBeClassroomStudent);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeClassroomStudent;
        }
    }
}
