using ProjectManagement.Core.Entities;

namespace ProjectManagement.Core.Contract
{
    public interface IProjectManagementReport
    {
        //public List<Assignment> GetAssignments();
        public List<Department> GetDepartments();
        public List<Employee> GetEmployees();
        public List<Project> GetProjects();
    }
}
