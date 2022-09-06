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
        }
    }
}
