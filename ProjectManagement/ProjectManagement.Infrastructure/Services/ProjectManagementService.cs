using ProjectManagement.Core.Contract;
using ProjectManagement.Core.Entities;
using System.Collections;
using static ProjectManagement.Infrastructure.Data.ProjectManagementDataInMemory;

namespace ProjectManagement.Infrastructure.Services
{
    public class ProjectManagementService:IProjectManagementReport
    {
        // Department 
        public List<Department> GetDepartments()
        {
            return departments;
        }
        
        public IEnumerable<Department> GetDepartments(int deptId)
        {
            return from dept in departments
                   where dept.DepartmentId == deptId
                   select dept;
        }

        public IEnumerable<Department> GetDepartments(string deptName)
        {
            return from dept in departments
                   where dept.DepartmentName == deptName
                   select dept;
        }
            
        public void DisplayDept(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentId} {department.DepartmentName} {department.PhoneNumber}");
            }

        }

        // Project
        public List<Project> GetProjects()
        {
            return projects;
        }
        public IEnumerable<Project> GetProjects(int projectdeptId)
        {
            return from pro in projects
                   where pro.DepartmentId == projectdeptId
                   select pro;
        }
        public IEnumerable<Project> GetProjects(string departmentName)
        {
            return from project in projects
                   join pro in departments on project.DepartmentId equals pro.DepartmentId
                   where pro.DepartmentName == departmentName
                   select project;
        }
        public void DisplayProject(IEnumerable<Project> projects)
        {
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.ProjectId} {project.ProjectName} {project.DepartmentId} {project.MaxHours} {project.StartDate} {project.EndDate}");
            }
        }

        // Employee
        public List<Employee> GetEmployees()
        {
            return employees;
        }
        public IEnumerable<Employee> GetEmployees(int empdeptId)
        {
            if(empdeptId < 5)
            {
                return from emp in employees
                       where emp.DepartmentId == empdeptId
                       select emp;
            }
            else
            {
                return from emp in employees
                       where emp.EmployeeNumber == empdeptId
                       select emp;
            }
        }
        public IEnumerable EmployeeCount()
        {
          var empdata=  (from emp in employees
                         group emp by emp.DepartmentId into g
             select new { DepartmentId = g.Key, Count = g.Count() });
            return empdata;
        }

        //public IEnumerable EmployeeSalary()
        //{
        //    var empdata = (from emp in employees
        //                   group emp by emp.DepartmentId into g
        //                   select new { DepartmentId = g.Key, Count = g.Sum() });
        //    return empdata;
        //}
        public void DisplayEmployee(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeNumber} {employee.EmployeeName} {employee.FirstName} {employee.LastName} {employee.Phone} {employee.Email} {employee.Salary}");
            }
        }

    }
}
