using ProjectManagement.Core.Contract;
using ProjectManagement.Core.Entities;
using ProjectManagement.Core.Model;
using System.Collections;
using static ProjectManagement.Infrastructure.Data.ProjectManagementDataInMemory;

namespace ProjectManagement.Infrastructure.Services
{
    public class ProjectManagementService:IProjectManagementReport
    {
        

        // Department 
       
        public IEnumerable<Department> GetDepartments(int? deptId=null,string? deptName=null)
        {
            if (deptId != null || deptName != null)
            {
                var deptDetails = from dept in departments
                             where (deptId == null || dept.DepartmentId == deptId) && (deptName == null || dept.DepartmentName == deptName)
                             select dept;
                return deptDetails;
            }
            return departments;
                  
        }

        // Project Data
        public IEnumerable<Project> GetProjects(int? projectdeptId=null,string? departmentName=null)
        {
            if (projectdeptId != null || departmentName != null)
            {
                var projectDetails= from project in projects
                                    join dept in departments on project.DepartmentId equals dept.DepartmentId
                                    where (projectdeptId==null || project.DepartmentId == projectdeptId) && (departmentName==null || dept.DepartmentName==departmentName)
                       select project;
                return projectDetails;
            }
            return projects;
        }

        // Employee Data
        
        public IEnumerable<Employee> GetEmployees(int? deptId=null,int? empNum=null)
        {
            if(deptId!=null || empNum!=null)
            {
                var empDetails = from emp in employees
                       where(deptId==null || emp.DepartmentId == deptId) && (empNum==null || emp.EmployeeNumber==empNum)
                       select emp;
                return empDetails;
            }
            return employees; 
           
        }
        public  IEnumerable EmployeeCount()
        {
          var empdata =  from emp in employees
                         group emp by emp.DepartmentId into g
             select new { DepartmentId = g.Key, Count = g.Count() };
            return empdata;
        }

        public IEnumerable EmployeeSalary()
        {
            var empdata = from emp in employees
                           group emp by emp.DepartmentId into g
                           select new { DepartmentId = g.Key, sum = g.Sum(x=>x.Salary) };
            return empdata;
        }

        // Add a property Name to Assignment enitity 

        public IEnumerable<CombineData> GetAllNames(int? deptId=null)
        {
            var names = (from dept in departments
                        join emp in employees
                        on dept.DepartmentId equals emp.DepartmentId
                        join project in projects 
                        on emp.DepartmentId equals project.DepartmentId
                        join ass in assignments 
                        on emp.EmployeeNumber equals ass.EmployeeNumber
                        where(deptId==null || emp.DepartmentId == deptId)
                        select new CombineData() { DepartmentName = dept.DepartmentName, ProjectName=project.ProjectName, EmployeeName = emp.EmployeeName, AssignmentName = ass.AssignmentName }).DistinctBy(a=>a.ProjectName);
            
            return names;
        }
        public List<Assignment> GetAssignments()
        {
            return assignments;
        }
        public  void GetDetails<T>(IEnumerable<T> collectiondata)
        {
            foreach (var data in collectiondata)
            {
                Console.WriteLine(data?.ToString());
            }

        }
    }
}
