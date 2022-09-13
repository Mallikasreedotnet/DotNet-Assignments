using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAttendanceAsync();
        Task<Attendance> GetAttendanceAsync(int attendanceId);
        Task<Attendance> CreateAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync(int attendanceId, Attendance attendance);
        Task<Attendance> DeleteAsync(int attendanceId);
    }
}
