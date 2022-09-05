using AutoMapper;
using SchoolManagement.Infrastructure.Entities;
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
        }
    }
}
