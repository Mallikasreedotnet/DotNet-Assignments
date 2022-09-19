using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class ExamResultEntityTypeConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.ToTable("ExamResult");

            builder.Property(e => e.ExamResultId).HasColumnName("examResultId");

            builder.Property(e => e.CourseId).HasColumnName("courseId");

            builder.Property(e => e.ExamId).HasColumnName("examId");

            builder.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false);
            //builder.HasNoKey();

            //builder.ToTable("ExamResult");

            //builder.Property(e => e.CourseId).HasColumnName("courseId");

            //builder.Property(e => e.ExamId).HasColumnName("examId");

            //builder.Property(e => e.Marks)
            //    .HasMaxLength(45)
            //    .IsUnicode(false);

            //builder.HasOne(d => d.Student)
            //    .WithMany()
            //    .HasForeignKey(d => d.StudentId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__ExamResul__Stude__6EF57B66");

        }
    }
}
