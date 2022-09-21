using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IClassroomStudentRepository
    {
        Task<IEnumerable<ClassroomStudent>> GetClassroomStudentAsync();
        Task<ClassroomStudent> GetClassroomStudentAsync(int classroomStudentId);
        Task<ClassroomStudent> CreateClassroomStudentAsync(ClassroomStudent classroomStudent);
        Task<ClassroomStudent> UpdateClassroomStudentAsync(ClassroomStudent classroomStudent);
        Task<ClassroomStudent> DeleteAsync(int classroomStudentId);
        

    }
}
