using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;
using static Dapper.SqlMapper;

namespace SchoolManagement.Infrastructure.EntityConfiguration
{
    internal class ParentEntityTypeConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.ToTable("Parent");

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

            }

        }
}
