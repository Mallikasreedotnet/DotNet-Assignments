using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Repository.EntityFramework;

namespace SchoolManagement.Infrastructure.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceAsync()
        {
            return await _attendanceRepository.GetAttendanceAsync();
        }

        public async Task<Attendance> GetAttendanceAsync(int attendanceId)
        {
            return await _attendanceRepository.GetAttendanceAsync(attendanceId);
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
           return await _attendanceRepository.CreateAttendanceAsync(attendance);
        }

        public async Task<Attendance> UpdateAttendanceAsync(int attendanceId, Attendance attendance)
        {
            var attendanceToBeUpdated = await GetAttendanceAsync(attendanceId);
            attendanceToBeUpdated.StudentId = attendance.StudentId;
            attendanceToBeUpdated.Date = attendance.Date;
            attendanceToBeUpdated.Status = attendance.Status;
            attendanceToBeUpdated.Remark = attendance.Remark;
            var data=await _attendanceRepository.UpdateAttendanceAsync(attendanceToBeUpdated);
            return data;
        }

        public async Task<Attendance> DeleteAsync(int attendanceId)
        {
            return await _attendanceRepository.DeleteAsync(attendanceId);
        }
    }
}
