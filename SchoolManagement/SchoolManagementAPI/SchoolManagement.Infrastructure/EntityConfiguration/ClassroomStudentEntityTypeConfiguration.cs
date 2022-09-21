using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class ClassroomStudentEntityTypeConfiguration : IEntityTypeConfiguration<ClassroomStudent>
    {
        public void Configure(EntityTypeBuilder<ClassroomStudent> builder)
        {
            builder.HasKey(e=>e.ClassroomStudentId);

            builder.ToTable("ClassroomStudent");
            
            builder.Property(e => e.ClassroomId).HasColumnName("ClassroomId");

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
