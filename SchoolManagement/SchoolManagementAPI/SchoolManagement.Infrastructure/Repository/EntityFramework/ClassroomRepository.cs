using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
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

        public async Task<IEnumerable<ClassroomDto>> GetClassroomAsync()
        {
            var query = "execute spGetClassroom";
            var classroomData = await _dbconnection.QueryAsync<ClassroomDto>(query);
            return classroomData;
        }

        public async Task<ClassroomDto> GetClassroomAsync(int classroomId)
        {
            var query = "execute spGetClassroomId @ClassroomId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ClassroomDto>(query, new { classroomId }));
        }

        public async Task<Classroom> GetClassroomByIdAsync(int classroomId)
        {
            var query = "select * from Classroom where ClassroomId=@classroomId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Classroom>(query, new { classroomId }));
        }

        public async Task<Classroom> CreateClassroomAsync(Classroom classroom)
        {
            _schoolDbContext.Classrooms.Add(classroom);
            await _schoolDbContext.SaveChangesAsync();
            return classroom;
        }

        public async Task<Classroom> UpdateClassroomAsync( Classroom classroom)
        {
            _schoolDbContext.Classrooms.Update(classroom);
            await _schoolDbContext.SaveChangesAsync();
            return classroom;
        }

        public async Task<Classroom> DeleteAsync(int classroomId)
        {
            var deletedToBeClassroom = await GetClassroomByIdAsync(classroomId);
            _schoolDbContext.Classrooms.Remove(deletedToBeClassroom);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeClassroom;
        }
    
        public async Task<int> GetClassroomWithStudentByCountAsync(int classroomId)
        {
            var classroomData = "execute spGetClassroomWithStudentCount @classroomId";
            var data=await _dbconnection.QuerySingleOrDefaultAsync<int>(classroomData,new{ classroomId });
              return data;
        }

        public async Task<IEnumerable<ClassroomDetailsDto>> GetClassroomWithStudentDetails(int classroomId)
        {
            var classroomData = "execute spGetClassroomWithStudentDetails @classroomId";
            var data = await _dbconnection.QueryAsync<ClassroomDetailsDto>(classroomData, new { classroomId });
            return data;
        }

        public async Task<Classroom> GetTeacherwithGrade(int gradeId,int teacherId, string section)
        {
            var query = "Select * from Classroom where gradeId=@gradeId and teacherId=@teacherId and section=@section";
            return  (await _dbconnection.QueryFirstOrDefaultAsync<Classroom>(query, new { gradeId,teacherId,section}));
        }

    }
}
