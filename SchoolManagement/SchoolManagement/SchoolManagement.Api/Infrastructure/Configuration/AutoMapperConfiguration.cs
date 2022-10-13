using AutoMapper;
using SchoolManagement.Api.ViewModel;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Api.Infrastructure.Configuration
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
            CreateMap<ExamResultVm, ExamResult>();
            CreateMap<ClassroomStudentVm, ClassroomStudent>();

        }
    }
}
