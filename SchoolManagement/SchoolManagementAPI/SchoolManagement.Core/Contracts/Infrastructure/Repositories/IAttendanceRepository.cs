using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAttendanceAsync();
        Task<Attendance> GetAttendanceAsync(int studentId);
        Task<Attendance> CreateAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync(int studentId, Attendance attendance);
        Task<Attendance> DeleteAsync(int studentId);

    }
}
