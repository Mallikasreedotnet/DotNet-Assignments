using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Extensions;

namespace SchoolManagement.Infrastructure.Data
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

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<ClassroomStudent> ClassroomStudents { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamResult> ExamResults { get; set; } = null!;
        public virtual DbSet<ExamType> ExamTypes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Parent> Parents { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localDb)\\MSSQLLocalDB;Database=SchoolManagementDb;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RegisterEntityConfigurations();
            //OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
