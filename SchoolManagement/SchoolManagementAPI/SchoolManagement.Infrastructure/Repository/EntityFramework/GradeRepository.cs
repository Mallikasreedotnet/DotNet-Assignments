using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        

        public GradeRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbConnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbConnection;
        }
        public async Task<IEnumerable<Grade>> GetGradeAsync()
        {
            var query = "Select * from Grade";
            var result = await _dbconnection.QueryAsync<Grade>(query);
            return result;
        }

        public async Task<Grade> GetGradeAsync(int gradeId)
        {
            var query = "Select * from Grade where gradeId=@gradeId";
            return (await _dbconnection.QueryAsync<Grade>(query, new { gradeId })).FirstOrDefault();
        }

        public async Task<Grade> CreateGradeAsync(Grade grade)
        {
            _schoolDbContext.Grades.Add(grade);
            await _schoolDbContext.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> UpdateGradeAsync(int gradeId,Grade grade)
        {
            var gradeToBeUpdated = await GetGradeAsync(gradeId);
            gradeToBeUpdated.Description = grade.Description;
            gradeToBeUpdated.Name = grade.Name;
            _schoolDbContext.Grades.Update(gradeToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return gradeToBeUpdated;
        }

        public async Task<Grade> DeleteAsync(int gradeId)
        {
            var deletedToBeGrade = await GetGradeAsync(gradeId);
            _schoolDbContext.Grades.Remove(deletedToBeGrade);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeGrade;
        }
    }
}
