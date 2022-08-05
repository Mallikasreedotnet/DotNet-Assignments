using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Services;
using Serilog;


ProjectManagementService service = new ProjectManagementService();
ServiceValidations serviceValidations = new ServiceValidations();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/projectmanagementapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
Log.Information("This is my first logging file.");



string choicevalue;
do
{
    Console.WriteLine("\t\t\t Welcome to Project Management Data.");
    Console.WriteLine();

    Console.WriteLine("Press 1 for get departments details for the department id.");
    Console.WriteLine("Press 2 for get department details for the department name.");
    Console.WriteLine("Press 3 for display all departments data.");
    Console.WriteLine("Press 4 for get the list of projects there for the department id.");
    Console.WriteLine("Press 5 for get list of projects there for the department name");
    Console.WriteLine("Press 6 for get all projects for each department.");
    Console.WriteLine("Press 7 for get the list of employees's there for the department id.");
    Console.WriteLine("Press 8 for get the employee's details for the employee id.");
    Console.WriteLine("Press 9 for get all employee's data");
    Console.WriteLine("Press 10 for get the number of employee's working for each department.");
    Console.WriteLine("Press 11 for get the total salary of employee's working for each department.");
    Console.WriteLine("Press 12 for get Department Name, Project Name, Assignment Name, Employee Name.");
    Console.WriteLine("press 13 for get department id that you want data. (Please enter department id.)");
    Console.WriteLine("Press 14 for get department name that you want data. (Please enter department name.)");
    Console.WriteLine("Press 15 for Search Data.");
    Console.WriteLine("Press 16 for get display assignment data.");
    Console.WriteLine();
    int choice = Convert.ToInt32(Console.ReadLine());
    try
    {
        switch (choice)
        {
            case 1:
                serviceValidations.DepartmentDetails();
                //// department details for the department Id. 

                //Console.WriteLine("\n Department details for the department Id.....\n ");
                ////int id=Convert.ToInt32(Console.ReadLine());
                ////if (id < 0)
                ////{
                ////    Log.Debug($"Plase enter vaild data : {id}");
                ////    throw new InvalidDataException();
                ////}
                //var deptId = service.GetDepartments();
                //service.CheckData(deptId);
                //Console.WriteLine();

                break;
            case 2:
                serviceValidations.ProjectDetails();
                // Department details for the Department Name.

                //Console.WriteLine("\n Department details for the Department Name.....\n");
                //var depName = service.GetDepartments(deptName: "@!#$#");
                //service.CheckData(depName);
                //Console.WriteLine();

                break;
            case 3:
                serviceValidations.EmployeeDetails();
                // Get the all department data

                //var deptData = service.GetDepartments();
                //Console.WriteLine("\n Get the all department data.....\n");
                //service.CheckData(deptData);
                //Console.WriteLine();
                break;
            case 4:
                serviceValidations.EmployeeCount();
                // Project Data
                // The list of projects there for the department Id

                //Console.WriteLine("\n The list of projects there for the department Id.....\n");
                //var projectdeptId = service.GetProjects(1);
                //service.CheckData(projectdeptId);
                //Console.WriteLine();

                break;
            case 5:
                serviceValidations.EmployeeSumSalary();
                // The list of projects there for the Department Name

                //Console.WriteLine("\n The list of projects there for the Department Name.....\n");
                //var projectdeptName = service.GetProjects(departmentName: "Accounting");
                //service.CheckData(projectdeptName);
                //Console.WriteLine();

                break;
            case 6:
                serviceValidations.PropertyName();
                // Get the all Project Data

                //var projectData = service.GetProjects();
                //Console.WriteLine("\n Get the all Project Data.....\n");
                //service.CheckData(projectData);
                //Console.WriteLine();
                break;
            case 7:
                serviceValidations.SearchingData();
                // Employee Data

                // The list of employees there for the department Id

                //Console.WriteLine("\n The list of employees there for the department Id.....\n");
                //var deptid = service.GetEmployees(1);
                //service.CheckData(deptid);

                break;

            case 8:
                serviceValidations.AssignmentDetails();
                // The employees details for the Employee Id

                //Console.WriteLine("\n The employees details for the Employee Id.....\n");
                //var empid = service.GetEmployees(empNum: 1111);
                //service.CheckData(empid);
                //Console.WriteLine();
                break;
            case 9:

                // Get all the employee data

                var GetEmployees = service.GetEmployees();
                Console.WriteLine("\n Get the all employee Data.....\n");
                service.CheckData(GetEmployees);
                Console.WriteLine();
                break;

            case 10:
                // The number of employees working for each department

                var employeecount = service.EmployeeCount();
                Console.WriteLine("\n The number of employees working for each department.....\n");
                foreach (var employee in employeecount)
                {
                    Console.WriteLine(employee.ToString());
                }
                Console.WriteLine();
                break;
            case 11:
                // The total salary paid for each department

                var empsalary = service.EmployeeSalary();
                Console.WriteLine("\n The total salary paid for each department.....\n");
                foreach (var emp in empsalary)
                {
                    Console.WriteLine(emp.ToString());
                }
                Console.WriteLine();
                break;
            case 12:

                // Add a property Name to Assignment enitity 

                var names = service.GetAllNames();
                Console.WriteLine("\n DepartmentName, ProjectName, AssignmentName, EmployeeName.....\n");
                service.CheckData(names);
                Console.WriteLine();
                break;
            case 13:
                //  Result by department wise by using department Id

                Console.WriteLine("\n Enter Department Id.....\n");
                int dataByDeptId = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (dataByDeptId == null || dataByDeptId < 0)
                    {
                        Log.Debug($"Please enter valid department Id : {dataByDeptId}");
                        throw new ArgumentOutOfRangeException("invalid data");
                    }
                    var deptmentid = service.GetCombineData(deptId: dataByDeptId);
                    service.CheckData(deptmentid);
                }
                catch (ArgumentOutOfRangeException ar)
                {
                    Console.WriteLine(ar.Message);
                    Log.Error(ar, $"something went wrong error:{ar.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Log.Error("exception");
                }
                break;
            case 14:
                // Result by department wise by using department Name

                Console.WriteLine("\n Enter any Department Name.....\n");
                string? dataByDeptName = Console.ReadLine();
                try
                {
                    if (string.IsNullOrEmpty(dataByDeptName))
                    {
                        throw new ArgumentNullException("Enter vaild Department Name");
                    }
                    var deptName = service.GetCombineData(deptName: dataByDeptName);
                    service.CheckData(deptName);
                }
                catch (ArgumentNullException fe)
                {
                    Log.Error(fe, $"something went wrong error:{fe.Message}");
                    // Console.WriteLine(fe.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 15:

                // Searching result by text

                Console.WriteLine("\n Enter any Data.......");
                string? searchingData = Console.ReadLine();
                try
                {
                    if (string.IsNullOrEmpty(searchingData))
                    {
                        throw new ArgumentNullException("There is no search data found..");
                    }

                    var searching = service.GetSearchingData(deptName: searchingData);
                    service.CheckData(searching);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 16:

                // Assignment Data

                var ass = service.GetAssignments();
                Console.WriteLine("Get the all Assinment Data.....");
                Console.WriteLine();
                service.CheckData(ass);
                Console.WriteLine();
                break;

            default:
                Console.WriteLine("Invaild Data");
                break;
        }
    }


    catch (InvalidDataException a)
    {
        Console.WriteLine(a.Message);
    }
    catch (ArgumentNullException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


    Console.WriteLine("Search data for again please enter yes");
    choicevalue = Console.ReadLine().ToLower();


} while (choicevalue == "yes");




















