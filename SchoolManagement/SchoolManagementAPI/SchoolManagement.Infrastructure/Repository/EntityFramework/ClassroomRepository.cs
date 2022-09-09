using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public ClassroomRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Classroom>> GetClassroomAsync()
        {
            var query = "select * from [Classroom]";
            var classroomData = await _dbconnection.QueryAsync<Classroom>(query);
            return classroomData;
        }

        public async Task<Classroom> GetClassroomAsync(int classroomId)
        {
            var query = "Select * from Classroom where classroomId=@ClassroomId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Classroom>(query, new { classroomId }));
        }

        public async Task<Classroom> CreateClassroomAsync(Classroom classroom)
        {
            _schoolDbContext.Classrooms.Add(classroom);
            await _schoolDbContext.SaveChangesAsync();
            return classroom;
        }

        public async Task<Classroom> UpdateClassroomAsync(int classroomId, Classroom classroom)
        {
            var classroomToBeUpdated = await GetClassroomAsync(classroomId);
            classroomToBeUpdated.Section = classroom.Section;
            classroomToBeUpdated.TeacherId= classroom.TeacherId;
            classroomToBeUpdated.Status= classroom.Status;
            classroomToBeUpdated.GradeId= classroom.GradeId;
            classroomToBeUpdated.Year= classroom.Year;
            classroomToBeUpdated.Remarks= classroom.Remarks;
            _schoolDbContext.Classrooms.Update(classroomToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return classroomToBeUpdated;
        }

        public async Task<Classroom> DeleteAsync(int classroomId)
        {
            var deletedToBeClassroom = await GetClassroomAsync(classroomId);
            _schoolDbContext.Classrooms.Remove(deletedToBeClassroom);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeClassroom;
        }
    

    }
}
