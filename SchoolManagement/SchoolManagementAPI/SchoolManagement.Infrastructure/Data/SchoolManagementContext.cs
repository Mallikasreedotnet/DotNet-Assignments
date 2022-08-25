using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolManagement.Infrastructure.Extensions;

namespace SchoolManagement.Infrastructure.Models
{
    public partial class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext()
        {

        }

        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Parent> Parents { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localDb)\\MSSQLLocalDB;Initial Catalog=SchoolManagement");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Parent>(entity =>
            //{
            //    entity.ToTable("Parent");

            //    entity.Property(e => e.ParentId)
            //        .ValueGeneratedNever()
            //        .HasColumnName("Parent_id");

            //    entity.Property(e => e.Dob)
            //        .HasColumnType("date")
            //        .HasColumnName("DOB");

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Fname)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LastLoginDate)
            //        .HasColumnType("date")
            //        .HasColumnName("Last_login_date");

            //    entity.Property(e => e.LastLoginIp)
            //        .HasMaxLength(45)
            //        .IsUnicode(false)
            //        .HasColumnName("Last_login_ip");

            //    entity.Property(e => e.Lname)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mobile)
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Password)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Phone)
            //        .HasMaxLength(15)
            //        .IsUnicode(false);
            //});
        //      protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            modelBuilder.RegisterEntityConfigurations();

        //    OnModelCreatingPartial(modelBuilder);
        //}


        //modelBuilder.Entity<Student>(entity =>
        //    {
        //        entity.ToTable("Student");

        //        entity.Property(e => e.StudentId)
        //            .ValueGeneratedNever()
        //            .HasColumnName("Student_id");

        //        entity.Property(e => e.DateOfJoin)
        //            .HasColumnType("date")
        //            .HasColumnName("Date_of_join");

        //        entity.Property(e => e.Dob)
        //            .HasColumnType("date")
        //            .HasColumnName("DOB");

        //        entity.Property(e => e.Email)
        //            .HasMaxLength(45)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Fname)
        //            .HasMaxLength(45)
        //            .IsUnicode(false);

        //        entity.Property(e => e.LastLoginDate)
        //            .HasColumnType("date")
        //            .HasColumnName("Last_login_date");

        //        entity.Property(e => e.LastLoginIp)
        //            .HasMaxLength(45)
        //            .IsUnicode(false)
        //            .HasColumnName("Last_login_ip");

        //        entity.Property(e => e.Lname)
        //            .HasMaxLength(45)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Mobile)
        //            .HasMaxLength(15)
        //            .IsUnicode(false);

        //        entity.Property(e => e.ParentId).HasColumnName("Parent_id");

        //        entity.Property(e => e.Password)
        //            .HasMaxLength(45)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Phone)
        //            .HasMaxLength(15)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.Parent)
        //            .WithMany(p => p.Students)
        //            .HasForeignKey(d => d.ParentId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK");
        //    });

            //modelBuilder.Entity<Teacher>(entity =>
            //{
            //    entity.ToTable("Teacher");

            //    entity.Property(e => e.TeacherId)
            //        .ValueGeneratedNever()
            //        .HasColumnName("Teacher_id");

            //    entity.Property(e => e.Dob)
            //        .HasColumnType("date")
            //        .HasColumnName("DOB");

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Fname)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LastLoginDate)
            //        .HasColumnType("date")
            //        .HasColumnName("Last_login_date");

            //    entity.Property(e => e.LastLoginIp)
            //        .HasMaxLength(45)
            //        .IsUnicode(false)
            //        .HasColumnName("Last_login_ip");

            //    entity.Property(e => e.Lname)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mobile)
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Password)
            //        .HasMaxLength(45)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Phone)
            //        .HasMaxLength(15)
            //        .IsUnicode(false);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
