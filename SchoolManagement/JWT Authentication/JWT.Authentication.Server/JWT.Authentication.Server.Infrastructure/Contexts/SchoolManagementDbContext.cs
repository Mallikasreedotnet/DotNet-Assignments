using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JWT.Authentication.Server.Core.Entities
{
    public partial class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext()
        {
        }

        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localDb)\\MSSQLLocalDB;Database=SchoolManagementDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.DateOfJoin)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_join");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginDate).HasColumnType("date");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
