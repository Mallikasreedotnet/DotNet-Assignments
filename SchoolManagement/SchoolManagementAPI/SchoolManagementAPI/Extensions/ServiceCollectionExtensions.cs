using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using SchoolManagementAPI.Infrastructure.Configuration;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Infrastructure.Services;

namespace SchoolManagementAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSystemServices(this IServiceCollection service)
        {
            service.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            service.AddEndpointsApiExplorer();
            service.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
            service.AddSwaggerGen();
            service.ConfigureOptions<ConfigureSwaggerOptions>();
            service.AddDataProtection();
            service.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
            service.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
        }

        public static  void RegisterApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SchoolManagementDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("schoolManagementDbContext")));
            
            
            services.AddTransient<IParentRepository, ParentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<IExamRepository,ExamRepository>();
            services.AddTransient<IExamResultRepository, ExamResultRepository>();
            services.AddTransient<IClassroomStudentRepository, ClassroomStudentRepository>();

            services.AddTransient<IDbConnection>(db => new SqlConnection(
                                configuration.GetConnectionString("schoolManagementDbContext")));

            //Services
            services.AddTransient<IParentService, ParentService>();
            services.AddTransient<IStudentService,StudentService>();
            services.AddTransient<ITeacherService,TeacherService>();
            services.AddTransient<IGradeService,GradeService>();
            services.AddTransient<IAttendanceService,AttendanceService>();
            services.AddTransient<IExamService,ExamService>();
            services.AddTransient<ICourseService,CourseService>();
            services.AddTransient<IClassroomService,ClassroomService>();
            services.AddTransient<IExamResultService, ExamResultService>();
            services.AddTransient<IClassroomStudentService, ClassroomStudentService>();

        }
    }
}
