using JWT.Authentication.Server.Core.Contract.Infrastructure.Repositories;
using JWT.Authentication.Server.Core.Entities;
using JWT.Authentication.Server.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JWT.Authentication.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register Repository

            services.AddTransient<IStudentRepository, AuthStudentRepository>();

            #endregion Register Repository

            #region Database

           
            services.AddScoped<SchoolManagementDbContext>()
                     .AddDbContextPool<SchoolManagementDbContext>(options =>
                     {
                         options.UseSqlServer(configuration.GetConnectionString("schoolManagementDbContext"));
                     });



            #endregion Database
        }
    }
}
