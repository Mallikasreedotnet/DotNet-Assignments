using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Services;
using Serilog;

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
    Console.WriteLine("Press 1 for get departments details.");
    Console.WriteLine("Press 2 for get project details.");
    Console.WriteLine("Press 3 for get employees details.");
    Console.WriteLine("Press 4 for get the number of employee's working for each department.");
    Console.WriteLine("Press 5 for get the total salary of employee's working for each department.");
    Console.WriteLine("Press 6 for get Department Name, Project Name, Assignment Name, Employee Name.");
    Console.WriteLine("Press 7 for Search Data.");
    Console.WriteLine("Press 8 for get display assignment data.");
    Console.WriteLine();
    int choice = Convert.ToInt32(Console.ReadLine());
    try
    {
        switch (choice)
        {
            case 1:
                serviceValidations.DepartmentDetails();
                break;
            case 2:
                serviceValidations.ProjectDetails();
                break;
            case 3:
                serviceValidations.EmployeeDetails();
                break;
            case 4:
                serviceValidations.EmployeeCount();
                break;
            case 5:
                serviceValidations.EmployeeSumSalary();
                break;
            case 6:
                serviceValidations.PropertyName();
                break;
            case 7:
                serviceValidations.SearchingData();
                break;
            case 8:
                serviceValidations.AssignmentDetails();
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
    catch (ArgumentOutOfRangeException e)
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




















