using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolManagement.Api.Infrastructure.Configuration;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using SchoolManagement.Infrastructure.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Data;
using System.Text;

namespace SchoolManagement.Api.Extensions
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

        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
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
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IExamResultRepository, ExamResultRepository>();
            services.AddTransient<IClassroomStudentRepository, ClassroomStudentRepository>();



            services.AddTransient<IDbConnection>(db => new SqlConnection(
                                configuration.GetConnectionString("schoolManagementDbContext")));

            //Services
            services.AddTransient<IParentService, ParentService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IClassroomService, ClassroomService>();
            services.AddTransient<IExamResultService, ExamResultService>();
            services.AddTransient<IClassroomStudentService, ClassroomStudentService>();
            services.AddTransient<IAuthService, AuthService>();

            #region Authentication 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        ClockSkew = TimeSpan.FromHours(2)
                    };
                });
            #endregion

            #region Swagger

            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Jwt Authentication"
                });
                option.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            #endregion
        }
    }
}
