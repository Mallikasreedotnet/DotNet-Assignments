using Dapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Classroom>> GetClassroomAsync()
        {
            var query = "execute spGetClassroom";
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

        public async Task<Classroom> UpdateClassroomAsync( Classroom classroom)
        {
            _schoolDbContext.Classrooms.Update(classroom);
            await _schoolDbContext.SaveChangesAsync();
            return classroom;
        }

        public async Task<Classroom> DeleteAsync(int classroomId)
        {
            var deletedToBeClassroom = await GetClassroomAsync(classroomId);
            _schoolDbContext.Classrooms.Remove(deletedToBeClassroom);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeClassroom;
        }
    
        public async Task<IEnumerable<ClassroomDetailsDto>> GetClassroomDetailsAsync(int classroomId)
        {
            var classroomDetails = await(from classroom in _schoolDbContext.Classrooms
                                   join classroomstudent in _schoolDbContext.ClassroomStudents
                                   on classroom.ClassroomId equals classroomstudent.ClassroomId
                                   join student in _schoolDbContext.Students
                                   on classroomstudent.StudentId equals student.StudentId
                                   join grade in _schoolDbContext.Grades
                                   on classroom.GradeId equals grade.GradeId
                                   where classroom.ClassroomId == classroomId
                                   select new ClassroomDetailsDto
                                   {
                                       StudentFname = student.Fname,
                                       StudentLname = student.Lname,
                                       GradeName=grade.Name,
                                       Year=classroom.Year,
                                       Section=classroom.Section,
                                   }).ToListAsync();
            return classroomDetails;

        }
    }
}
