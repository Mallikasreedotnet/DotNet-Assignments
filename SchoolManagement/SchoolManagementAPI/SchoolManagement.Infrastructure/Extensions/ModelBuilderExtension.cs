using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.EntityConfiguration;

namespace SchoolManagement.Infrastructure.Extensions
{
    internal static class ModelBuilderExtensions { 
    internal static void RegisterEntityConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ParentEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherEntityTypeConfiguration());
    }
    }
}
