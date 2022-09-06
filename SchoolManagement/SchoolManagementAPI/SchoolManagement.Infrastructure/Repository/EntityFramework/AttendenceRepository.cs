using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class AttendenceRepository : IAttendenceRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        public AttendenceRepository(SchoolManagementDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        //public async Task<IEnumerable<Attendance>> GetAttendancesAsync()
        //{
        //    var attendenceQuery = from attendence in 
        //}
    }
}
