using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class GradeEntityTypeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("Grade");

            builder.Property(e => e.GradeId).HasColumnName("GradeId");

            builder.Property(e => e.Description)
                .HasMaxLength(45)
            .IsUnicode(false);

            builder.Property(e => e.GradeName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
