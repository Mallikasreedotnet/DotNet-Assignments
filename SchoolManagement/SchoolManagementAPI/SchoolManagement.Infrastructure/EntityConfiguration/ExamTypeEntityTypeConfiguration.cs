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
    internal class ExamTypeEntityTypeConfiguration : IEntityTypeConfiguration<ExamType>
    {
        public void Configure(EntityTypeBuilder<ExamType> builder)
        {
            builder.ToTable("ExamType");

            builder.Property(e => e.ExamTypeId).HasColumnName("examTypeId");

            builder.Property(e => e.Description)
                .HasMaxLength(45)
            .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
