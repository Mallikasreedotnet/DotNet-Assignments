using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class ExamResultEntityTypeConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.ToTable("ExamResult");

            builder.Property(e => e.ExamResultId).HasColumnName("ExamResultId");

            builder.Property(e => e.CourseId).HasColumnName("CourseId");

            builder.Property(e => e.ExamId).HasColumnName("ExamId");

            builder.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.Result)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Result");

            builder.Property(e => e.ExamGrade)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ExamGrade");
        }
    }
}
