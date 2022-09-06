using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;


namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class AttendanceEntityTypeConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasNoKey();

            builder.ToTable("Attendance");

            builder.Property(e => e.Date).HasColumnType("date");

            builder.Property(e => e.Remark).HasColumnType("text");

            builder.Property(e => e.Student_id).HasColumnName("Student_id");

            builder.HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.Student_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Stude__6754599E");
        }
    }
}
