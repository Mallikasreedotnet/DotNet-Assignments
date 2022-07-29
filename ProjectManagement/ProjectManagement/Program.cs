using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Services;


 
ProjectManagementService service = new ProjectManagementService();

// Department Data

var depId = service.GetDepartments(3);
Console.WriteLine("Department details for the department Id..... ");
Console.WriteLine();
service.DisplayDept(depId);
Console.WriteLine();

var depName = service.GetDepartments("Marketing");
Console.WriteLine("Department details for the Department Name..... ");
Console.WriteLine();
service.DisplayDept(depName);
Console.WriteLine();

var deptData = service.GetDepartments();
Console.WriteLine("Get the all department data");
Console.WriteLine();
service.DisplayDept(deptData);
Console.WriteLine();


// Project Data

var projectdeptId = service.GetProjects(3);
Console.WriteLine("The list of projects there for the department Id.....");
Console.WriteLine();
service.DisplayProject(projectdeptId);
Console.WriteLine();

var projectdeptName = service.GetProjects("Marketing");
Console.WriteLine("The list of projects there for the Department Name.....");
Console.WriteLine();
service.DisplayProject(projectdeptName);
Console.WriteLine();

var projectData = service.GetProjects();
Console.WriteLine("Get the all Project Data.....");
Console.WriteLine();
service.DisplayProject(projectData);
Console.WriteLine();

// Employee Data

var deptid= service.GetEmployees(2);
Console.WriteLine("The list of employees there for the department Id.....");
Console.WriteLine();
service.DisplayEmployee(deptid);
Console.WriteLine();

var empid = service.GetEmployees(111);
Console.WriteLine("The employees details for the Employee Id.....");
Console.WriteLine();
service.DisplayEmployee(empid);
Console.WriteLine();

var employeecount=service.EmployeeCount();
foreach (var employee in employeecount)
{
    Console.WriteLine(employee.ToString());
}

