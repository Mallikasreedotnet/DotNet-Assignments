using ProjectManagement.Core.Entities;
using ProjectManagement.Core.Model;
using System.Collections;

namespace ProjectManagement.Core.Contract
{
    public interface IProjectManagementReport
    {
        public List<Assignment> GetAssignments();
          
        public IEnumerable<Department> GetDepartments(int? deptId = null, string? deptName = null);
        public IEnumerable<Employee> GetEmployees(int? deptId = null, int? empNum = null);
        public IEnumerable<Project> GetProjects(int? projectdeptId = null, string? departmentName = null);
        public void GetDetails<T>(IEnumerable<T> collectiondata);
        public IEnumerable EmployeeCount();
        public IEnumerable EmployeeSalary();
        public IEnumerable<ProjectResourceDetails> GetAllNames();
        public IEnumerable<ProjectResourceDetails> GetCombineData( int? deptId = null, string? deptName = null);
        public IEnumerable<ProjectResourceDetails> GetSearchingData( string deptName);

    }
}
