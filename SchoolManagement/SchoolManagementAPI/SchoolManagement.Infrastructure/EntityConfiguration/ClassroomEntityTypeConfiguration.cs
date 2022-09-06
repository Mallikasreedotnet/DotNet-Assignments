using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;
using static Dapper.SqlMapper;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class ClassroomEntityTypeConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.ToTable("Classroom");

            builder.Property(e => e.ClassroomId).HasColumnName("classroomId");

            builder.Property(e => e.GradeId).HasColumnName("gradeId");

            builder.Property(e => e.Remarks)
                .HasMaxLength(45)
            .IsUnicode(false);

            builder.Property(e => e.Section)
                .HasMaxLength(2)
                .IsUnicode(false)
            .IsFixedLength();

            builder.Property(e => e.Teacher_id).HasColumnName("Teacher_id");

            builder.HasOne(d => d.Grade)
                .WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classroom__grade__5EBF139D");

            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.Teacher_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classroom__Teach__5FB337D6");
        }
    }
}
