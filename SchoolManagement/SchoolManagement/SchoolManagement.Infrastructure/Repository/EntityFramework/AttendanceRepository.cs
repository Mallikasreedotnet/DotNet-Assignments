using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
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

        public async Task<IEnumerable<AttendanceDto>> GetAttendanceAsync()
        {
            var query = "execute spGetAttendance";
            var attendanceData = await _dbconnection.QueryAsync<AttendanceDto>(query);
            return attendanceData;
        }

        public async Task<AttendanceDto> GetAttendanceAsync(int attendanceId)
        {
            var query = "execute spGetAttendanceId @AttendanceId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<AttendanceDto>(query, new { attendanceId }));
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int attendanceId)
        {
            var query = "select * from Attendance where AttendanceId=@attendanceId";
           return await _dbconnection.QueryFirstOrDefaultAsync<Attendance>(query, new { attendanceId });
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            attendance.Date = DateTime.Now;
            _schoolDbContext.Attendances.Add(attendance);
            await _schoolDbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
        {
            _schoolDbContext.Attendances.Update(attendance);
            await _schoolDbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<StudentAttendanceDto> GetStudentAttendanceAsync(int studentId)
        {
            var studentAttendance = await (from student in _schoolDbContext.Students
                                           join attendance in _schoolDbContext.Attendances
                                           on student.StudentId equals attendance.StudentId
                                           where student.StudentId == studentId
                                           select new StudentAttendanceDto
                                           {
                                               StudentFname = student.Fname,
                                               StudentLname = student.Lname,
                                               StudentEmail = student.Email,
                                               Date = attendance.Date,
                                               Remark = attendance.Remark,
                                               Status = attendance.Status
                                           }).FirstAsync();
            return studentAttendance;
        }

        public async Task<Attendance> DeleteAsync(int attendanceId)
        {
            var deletedToBeAttendance = await GetAttendanceByIdAsync(attendanceId);
            _schoolDbContext.Attendances.Remove(deletedToBeAttendance);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeAttendance;
        }
    }
}
