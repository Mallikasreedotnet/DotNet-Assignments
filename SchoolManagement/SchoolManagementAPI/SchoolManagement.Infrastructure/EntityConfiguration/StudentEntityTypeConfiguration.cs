using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;
using static Dapper.SqlMapper;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    public class StudentEntityTypeConfiguration:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            //builder.Property(e => e.ClassroomId).HasColumnName("classroomId");

            builder.Property(e => e.DateOfJoin)
                .HasColumnType("date")
                .HasColumnName("Date_of_join");

            builder.Property(e => e.Dob)
                .HasColumnType("date")
            .HasColumnName("DOB");

            builder.Property(e => e.Email)
                .HasMaxLength(45)
            .IsUnicode(false);

            builder.Property(e => e.Fname)
                .HasMaxLength(45)
            .IsUnicode(false);

            builder.Property(e => e.LastLoginDate).HasColumnType("date");

            builder.Property(e => e.LastLoginIp)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.Lname)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.HasOne(d => d.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__Parent___38996AB5");

            //builder.HasOne(d => d.Classroom)
            //   .WithMany(p => p.Students)
            //   .HasForeignKey(d => d.ClassroomId)
            //   .OnDelete(DeleteBehavior.ClientSetNull)
            //   .HasConstraintName("FK");
        }
    }
}
