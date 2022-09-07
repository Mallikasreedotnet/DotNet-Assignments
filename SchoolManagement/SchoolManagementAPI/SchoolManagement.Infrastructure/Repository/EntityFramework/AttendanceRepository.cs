using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public AttendanceRepository(SchoolManagementDbContext schoolDbContext,IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceAsync()
        {
            var query = "select * from [Attendance]";
            var attendanceData = await _dbconnection.QueryAsync<Attendance>(query);
            return attendanceData;
        }

        public async Task<Attendance> GetAttendanceAsync(int studentId)
        {
            var query = "Select * from Attendance where Student_id=@StudentId";
            return (await _dbconnection.QueryAsync<Attendance>(query, new { studentId })).FirstOrDefault();
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            var attendenceRecord = new Attendance()
            {
                Date = DateTime.Now,
                Remark = attendance.Remark,
                Status = attendance.Status,
                Student_id = attendance.Student_id
            };
            _schoolDbContext.Attendances.Add(attendenceRecord);
            await _schoolDbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAttendanceAsync(int studentId, Attendance attendance)
        {
            var attendanceToBeUpdated = await GetAttendanceAsync(studentId);
            attendanceToBeUpdated.Student_id = attendance.Student_id;
            attendanceToBeUpdated.Date = attendance.Date;
            attendanceToBeUpdated.Status = attendance.Status;
            attendanceToBeUpdated.Remark = attendance.Remark;
            _schoolDbContext.Attendances.Update(attendanceToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return attendanceToBeUpdated;
        }

        public async Task<Attendance> DeleteAsync(int studentId)
        {
            var deletedToBeAttendance = await GetAttendanceAsync(studentId);
            _schoolDbContext.Attendances.Remove(deletedToBeAttendance);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeAttendance;
        }
    }
}
