using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDto>> GetAttendanceAsync();
        Task<AttendanceDto> GetAttendanceAsync(int attendanceId);
        Task<Attendance> CreateAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync(int attendanceId, Attendance attendance);
        Task<Attendance> DeleteAsync(int attendanceId);
        Task<Attendance> GetAttendanceByIdAsync(int attendanceId);
        Task<StudentAttendanceDto> GetStudentAttendanceAsync(int studentId);
    }
}
