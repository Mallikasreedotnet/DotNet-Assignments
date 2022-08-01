using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Services;


 
ProjectManagementService service = new ProjectManagementService();

// department details for the department Id. 

var depId = service.GetDepartments(3);
Console.WriteLine("Department details for the department Id..... ");
Console.WriteLine();
service.GetDetails(depId);
Console.WriteLine();


//Department details for the Department Name.

var depName = service.GetDepartments(deptName: "Finance");
Console.WriteLine("Department details for the Department Name..... ");
Console.WriteLine();
service.GetDetails(depName);
Console.WriteLine();

// Get the all department data

var deptData = service.GetDepartments();
Console.WriteLine("Get the all department data");
Console.WriteLine();
service.GetDetails(deptData);
Console.WriteLine();


// Project Data

var projectdeptId = service.GetProjects(3);
Console.WriteLine("The list of projects there for the department Id.....");
Console.WriteLine();
service.GetDetails(projectdeptId);
Console.WriteLine();

var projectdeptName = service.GetProjects(departmentName:"Marketing");
Console.WriteLine("The list of projects there for the Department Name.....");
Console.WriteLine();
service.GetDetails(projectdeptName);
Console.WriteLine();

var projectData = service.GetProjects();
Console.WriteLine("Get the all Project Data.....");
Console.WriteLine();
service.GetDetails(projectData);
Console.WriteLine();

// Employee Data

var deptid = service.GetEmployees(1);
Console.WriteLine("The list of employees there for the department Id.....");
Console.WriteLine();
service.GetDetails(deptid);
Console.WriteLine();

var empid = service.GetEmployees(empNum:111);
Console.WriteLine("The employees details for the Employee Id.....");
Console.WriteLine();
service.GetDetails(empid);
Console.WriteLine();

var employeecount =service.EmployeeCount();
Console.WriteLine("The number of employees working for each department.....");
foreach (var employee in employeecount)
{
    Console.WriteLine(employee.ToString());
}
Console.WriteLine();

var empsalary=service.EmployeeSalary(); 
Console.WriteLine("The total salary paid for each department.....");
foreach(var emp in empsalary)
{
    Console.WriteLine(emp.ToString());
}
Console.WriteLine();

// Add a property Name to Assignment enitity 

Console.WriteLine("DepartmentName, ProjectName, AssignmentName, EmployeeName.....");
var names=service.GetAllNames();
Console.WriteLine();
service.GetDetails(names);
Console.WriteLine();

Console.WriteLine("Take input from the console.....");
Console.WriteLine();
var deptId = service.GetAllNames(deptId:2);
service.GetDetails(deptId);




// Assignment Data

//var ass = service.GetAssignments();
//Console.WriteLine("Get the all Assinment Data.....");
//Console.WriteLine();
//service.GetDetails(ass);
//Console.WriteLine();

