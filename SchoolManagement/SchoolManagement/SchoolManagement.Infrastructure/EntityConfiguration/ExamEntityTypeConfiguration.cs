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
    internal class ExamEntityTypeConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exam");

            builder.Property(e => e.ExamId).HasColumnName("ExamId");

            builder.Property(e => e.ExamTypeId).HasColumnName("ExamTypeId");

            builder.Property(e => e.ExamName)
                .HasMaxLength(45)
            .IsUnicode(false);

            builder.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("StartDate");

            builder.HasOne(d => d.ExamType)
                .WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exam__examTypeId__6C190EBB");
        }
    }
}
