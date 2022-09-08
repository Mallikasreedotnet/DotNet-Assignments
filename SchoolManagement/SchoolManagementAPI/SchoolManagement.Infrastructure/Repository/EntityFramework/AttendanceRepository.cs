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

        public async Task<Attendance> GetAttendanceAsync(int attendanceId)
        {
            var query = "Select * from Attendance where AttendanceId=@AttendanceId";
            return (await _dbconnection.QueryAsync<Attendance>(query, new { attendanceId })).FirstOrDefault();
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            //var attendanceRecord = new Attendance()
            //{
            //    Date = DateTime.Now,
            //    Remark = attendance.Remark,
            //    Status = attendance.Status,
            //    StudentId = attendance.StudentId
            //};
            attendance.Date = DateTime.Now;
            _schoolDbContext.Attendances.Add(attendance);
            await _schoolDbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAttendanceAsync(int attendanceId, Attendance attendance)
        {
            var attendanceToBeUpdated = await GetAttendanceAsync(attendanceId);
            attendanceToBeUpdated.StudentId = attendance.StudentId;
            attendanceToBeUpdated.Date = attendance.Date;
            attendanceToBeUpdated.Status = attendance.Status;
            attendanceToBeUpdated.Remark = attendance.Remark;
            _schoolDbContext.Attendances.Update(attendanceToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return attendanceToBeUpdated;
        }

        public async Task<Attendance> DeleteAsync(int attendanceId)
        {
            var deletedToBeAttendance = await GetAttendanceAsync(attendanceId);
            _schoolDbContext.Attendances.Remove(deletedToBeAttendance);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeAttendance;
        }
    }
}
