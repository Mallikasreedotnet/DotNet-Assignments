using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class ClassroomStudentEntityTypeConfiguration : IEntityTypeConfiguration<ClassroomStudent>
    {
        public void Configure(EntityTypeBuilder<ClassroomStudent> builder)
        {
            builder.HasNoKey();

            builder.ToTable("ClassroomStudent");
            
            builder.Property(e => e.ClassroomId).HasColumnName("classroomId");

            builder.HasOne(d => d.Classroom)
                .WithMany()
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classroom__class__6477ECF3");

            builder.HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classroom__Stude__656C112C");

        }
    }
}
