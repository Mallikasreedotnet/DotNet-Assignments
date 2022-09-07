using AutoMapper;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Configuration
{
    internal class AutoMapperConfiguration : Profile
    {
        internal AutoMapperConfiguration()
        {
            CreateMap<ParentVm, Parent>();
            CreateMap<StudentVm, Student>();
            CreateMap<TeacherVm, Teacher>();
            CreateMap<GradeVm, Grade>();
            CreateMap<CourseVm, Course>();
            CreateMap<ClassroomVm, Classroom>();
            CreateMap<AttendanceVm, Attendance>();
            CreateMap<ExamVm, Exam>();
            CreateMap<ExamTypeVm, ExamType>();  

        }
    }
}
