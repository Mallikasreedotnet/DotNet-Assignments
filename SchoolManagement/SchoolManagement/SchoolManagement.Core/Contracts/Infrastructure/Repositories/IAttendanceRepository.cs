using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<AttendanceDto>> GetAttendanceAsync();
        Task<AttendanceDto> GetAttendanceAsync(int attendanceId);
        Task<Attendance> CreateAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync( Attendance attendance);
        Task<Attendance> DeleteAsync(int attendanceId);
        Task<StudentAttendanceDto> GetStudentAttendanceAsync(int studentId);
        Task<Attendance> GetAttendanceByIdAsync(int attendanceId);
    }
}
