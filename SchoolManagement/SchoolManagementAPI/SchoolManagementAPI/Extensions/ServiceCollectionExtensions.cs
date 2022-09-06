using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using System.Data;

namespace SchoolManagementAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSystemServices(this IServiceCollection service)
        {
            // Add services to the container.

            service.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();


        }

        public static  void RegisterApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            //builder.Services.AddScoped<ITeacher, TeacherRepository>();
            //DbConnection connection = new SqlConnection(@"Server= (localDb)\MSSQLLocalDB; DataBase=SchoolManagementDb;Trusted_Connection=True;");

            services.AddDbContext<SchoolManagementDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("schoolManagementDbContext")));
            services.AddTransient<IParentRepository, ParentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<IDbConnection>(db => new SqlConnection(
                                configuration.GetConnectionString("schoolManagementDbContext")));
        }
    }
}
