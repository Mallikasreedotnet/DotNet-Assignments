using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAttendanceAsync();
        Task<Attendance> GetAttendanceAsync(int studentId);
        Task<Attendance> CreateAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync( Attendance attendance);
        Task<Attendance> DeleteAsync(int studentId);
        Task<StudentAttendanceDto> GetStudentAttendanceAsync(int studentId);
    }
}
