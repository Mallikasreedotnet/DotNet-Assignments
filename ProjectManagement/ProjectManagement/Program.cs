using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Services;


 
ProjectManagementService service = new ProjectManagementService();

// department details for the department Id. 

Console.WriteLine("\n Department details for the department Id.....\n ");
try
{
    var deptId = service.GetDepartments(4);
    if (!deptId.Any())
    {
        throw new Exception("Please enter vaild Department Id");
    }
    service.GetDetails(deptId);
    Console.WriteLine();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Department details for the Department Name.

Console.WriteLine("\n Department details for the Department Name.....\n");
try
{
    var depName = service.GetDepartments(deptName: "Marketing");
    if (!depName.Any())
    {
        throw new Exception("Please enter vaild Department Name");
    }
    service.GetDetails(depName);
    Console.WriteLine();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

// Get the all department data

var deptData = service.GetDepartments();
Console.WriteLine("\n Get the all department data.....\n");
service.GetDetails(deptData);
Console.WriteLine();


// Project Data
// The list of projects there for the department Id

Console.WriteLine("\n The list of projects there for the department Id.....\n");
try
{
    var projectdeptId = service.GetProjects(1);
    if (!projectdeptId.Any())
    {
        Console.WriteLine("Please enter vaild Department Id");
    }

    service.GetDetails(projectdeptId);
    Console.WriteLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// The list of projects there for the Department Name

Console.WriteLine("\n The list of projects there for the Department Name.....\n");
try
{
    var projectdeptName = service.GetProjects(departmentName: "Accounting");
    if (!projectdeptName.Any())
    {
        throw new Exception("Please enter vaild Department Name");
    }
    service.GetDetails(projectdeptName);
    Console.WriteLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Get the all Project Data

var projectData = service.GetProjects();
Console.WriteLine("\n Get the all Project Data.....\n");
service.GetDetails(projectData);
Console.WriteLine();

// Employee Data

// The list of employees there for the department Id

Console.WriteLine("\n The list of employees there for the department Id.....\n");
try
{
    var deptid = service.GetEmployees(1);
    if (!deptid.Any())
    {
        throw new Exception("Please enter vaild Department Id");
    }
    service.GetDetails(deptid);
    Console.WriteLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// The employees details for the Employee Id

Console.WriteLine("\n The employees details for the Employee Id.....\n");
try
{
    var empid = service.GetEmployees(empNum: 111);
    if (!empid.Any())
    {
        throw new Exception("Please enter vaild Employee Id");
    }
    service.GetDetails(empid);
    Console.WriteLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// The number of employees working for each department

var employeecount =service.EmployeeCount();
Console.WriteLine("\n The number of employees working for each department.....\n");
foreach (var employee in employeecount)
{
    Console.WriteLine(employee.ToString());
}
Console.WriteLine();


// The total salary paid for each department

var empsalary =service.EmployeeSalary(); 
Console.WriteLine("\n The total salary paid for each department.....\n");
foreach(var emp in empsalary)
{
    Console.WriteLine(emp.ToString());
}
Console.WriteLine();


// Add a property Name to Assignment enitity 

var names=service.GetAllNames();
Console.WriteLine("\n DepartmentName, ProjectName, AssignmentName, EmployeeName.....\n");
service.GetDetails(names);
Console.WriteLine();


//  Result by department wise by using department Id

Console.WriteLine("\n Enter Department Id.....\n");
int dataByDeptId = Convert.ToInt32(Console.ReadLine());
try
{
    if(dataByDeptId==null || dataByDeptId < 0 )
    {
        throw new ArgumentOutOfRangeException();
    }
    var deptId = service.GetCombineData(deptId: dataByDeptId);
    service.GetDetails(deptId);
}
catch(ArgumentOutOfRangeException)
{
    Console.WriteLine("Enter vaild Department Id");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}


// Result by department wise by using department Name

Console.WriteLine("\n Enter any Department Name.....\n");
string? dataByDeptName = Console.ReadLine();
try
{
    if (string.IsNullOrEmpty(dataByDeptName))
    {
        throw new Exception("Enter vaild Department Name");
    }
    var deptName = service.GetCombineData(deptName: dataByDeptName);
    service.GetDetails(deptName);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Searching result by text

Console.WriteLine("\n Enter any Data.......");
string? searchingData = Console.ReadLine();
try
{
    if(string.IsNullOrEmpty(searchingData))
    {
        throw new Exception("There is no search data found..");
    }
    
    var searching = service.GetSearchingData(deptName: searchingData);
    service.GetDetails(searching);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}


// Assignment Data

//var ass = service.GetAssignments();
//Console.WriteLine("Get the all Assinment Data.....");
//Console.WriteLine();
//service.GetDetails(ass);
//Console.WriteLine();

