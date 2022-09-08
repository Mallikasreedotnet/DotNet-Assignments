using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

                builder.Property(e => e.CourseId).HasColumnName("courseId");

        builder.Property(e => e.Description)
                    .HasMaxLength(45)
                    .IsUnicode(false);

        builder.Property(e => e.GradeId).HasColumnName("gradeId");

        builder.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);

        builder.HasOne(d => d.Grade)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__gradeId__628FA481");
        }

    }
}
