using ProjectManagement.Core.Contract;
using ProjectManagement.Core.Entities;
using ProjectManagement.Core.Model;
using System.Collections;
using static ProjectManagement.Infrastructure.Data.ProjectManagementDataInMemory;
using Serilog;

namespace ProjectManagement.Infrastructure.Services
{
    public class ProjectManagementService : IProjectManagementReport
    {
        // Department Data

        public IEnumerable<Department> GetDepartments(int? deptId = null, string? deptName = null)
        {
            var deptDetails = from dept in departments
                              where (deptId == null || dept.DepartmentId == deptId) && (deptName == null || dept.DepartmentName == deptName)
                              select dept;
            return deptDetails;
        }

        // Project Data
        public IEnumerable<Project> GetProjects(int? projectdeptId = null, string? departmentName = null)
        {
            var projectDetails = from project in projects
                                 join dept in departments on project.DepartmentId equals dept.DepartmentId
                                 where (projectdeptId == null || project.DepartmentId == projectdeptId) && (departmentName == null || dept.DepartmentName == departmentName)
                                 select project;
            return projectDetails;
        }

        // Employee Data

        public IEnumerable<Employee> GetEmployees(int? deptId = null, int? empNum = null)
        {
            var empDetails = from emp in employees
                             where (deptId == null || emp.DepartmentId == deptId) && (empNum == null || emp.EmployeeNumber == empNum)
                             select emp;
            return empDetails;
        }

        //  The number of employees working for each department
        public IEnumerable EmployeeCount()
        {
            var empdata = from emp in employees
                          group emp by emp.DepartmentId into g
                          select new { DepartmentId = g.Key, Count = g.Count() };
            return empdata;
        }

        // The total salary paid for each department. 
        public IEnumerable EmployeeSalary()
        {
            var empdata = from emp in employees
                          group emp by emp.DepartmentId into g
                          select new { DepartmentId = g.Key, sum = g.Sum(x => x.Salary) };
            return empdata;
        }

        // Add a property Name to Assignment enitity 

        // DepartmentName, Project Name, Assignment Name, Employee Name 
        public IEnumerable<ProjectResourceDetails> GetAllNames()
        {
            var names = (from dept in departments
                         join emp in employees
                         on dept.DepartmentId equals emp.DepartmentId
                         join project in projects
                         on emp.DepartmentId equals project.DepartmentId
                         join ass in assignments
                         on emp.EmployeeNumber equals ass.EmployeeNumber
                         select new { DepartmentName = dept.DepartmentName, ProjectName = project.ProjectName, EmployeeName = emp.EmployeeName, AssignmentName = ass.AssignmentName }).Distinct();

            var combiningNames = from name in names
                                 select new ProjectResourceDetails() { DepartmentName = name.DepartmentName, ProjectName = name.ProjectName, EmployeeName = name.EmployeeName, AssignmentName = name.AssignmentName };
            return combiningNames;
        }

        // To return above result by department wise 
        public IEnumerable<ProjectResourceDetails> GetCombineData(int? deptId = null, string? deptName = null)
        {
            var departmentDetails = from combine in GetAllNames()
                                    join dept in departments on combine.DepartmentName equals dept.DepartmentName
                                    where (deptId == null || dept.DepartmentId.Equals(deptId)) && (deptName == null || combine.DepartmentName.Contains(deptName))
                                    select combine;
            return departmentDetails;
        }

        // To search above result by text 
        public IEnumerable<ProjectResourceDetails> GetSearchingData(string? deptName)
        {
            var searchingDetails = from combines in GetAllNames()
                                   where combines.DepartmentName.Contains(deptName) || combines.EmployeeName.Contains(deptName) || combines.ProjectName.Contains(deptName) || combines.AssignmentName.Contains(deptName)
                                   select combines;
            return searchingDetails;
        }
        public List<Assignment> GetAssignments()
        {
            return assignments;
        }
        public void GetDetails<T>(IEnumerable<T> collectiondata)
        {
            foreach (var data in collectiondata)
            {
                Console.WriteLine(data?.ToString());
            }
        }
        public void CheckData<T>(IEnumerable<T> CollecatedData)
        {
            if (CollecatedData.Any())
            {
                GetDetails(CollecatedData);
            }
            else
            {
                Console.WriteLine("data not found Please enter valid data");
            }

        }
    }
}
