using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;
using static Dapper.SqlMapper;


namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class AttendanceEntityTypeConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(e => e.AttendanceId);

            builder.ToTable("Attendance");
            builder.Property(e => e.AttendanceId).HasColumnName("AttendanceId");
            builder.Property(e => e.Date).HasColumnType("date");

            builder.Property(e => e.Remark).HasColumnType("text");

            builder.HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Stude__6754599E");
            
        }
    }
}
