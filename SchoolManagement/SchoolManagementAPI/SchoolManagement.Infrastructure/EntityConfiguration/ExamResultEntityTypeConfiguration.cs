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
            builder.HasNoKey();

            builder.ToTable("ExamResult");

            builder.Property(e => e.CourseId).HasColumnName("courseId");

            builder.Property(e => e.ExamId).HasColumnName("examId");

            builder.Property(e => e.Marks)
                .HasMaxLength(45)
            .IsUnicode(false);

            builder.Property(e => e.Student_id).HasColumnName("Student_id");

            builder.HasOne(d => d.Course)
                .WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamResul__cours__6FE99F9F");

            builder.HasOne(d => d.Exam)
                .WithMany()
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamResul__examI__6E01572D");

            builder.HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.Student_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamResul__Stude__6EF57B66");
        }
    }
}
