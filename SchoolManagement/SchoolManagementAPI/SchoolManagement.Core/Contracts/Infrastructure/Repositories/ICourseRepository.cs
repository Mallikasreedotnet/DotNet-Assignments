﻿using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCourseAsync();
        Task<Course> GetCourseAsync(int courseId);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(Course course);
        Task<Course> DeleteAsync(int courseId);
        Task<Course> GetCourseName(string Name,int grade);
    }
}
