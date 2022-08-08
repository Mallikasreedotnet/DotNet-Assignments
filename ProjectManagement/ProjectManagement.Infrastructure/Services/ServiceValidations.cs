namespace ProjectManagement.Infrastructure.Services
{
    public class ServiceValidations
    {
        ProjectManagementService service = new ProjectManagementService();

        // Department Data
        public void DepartmentDetails()
        {
            Console.WriteLine("Press 1 for get departments details for the department id.");
            Console.WriteLine("Press 2 for get department details for the department name.");
            Console.WriteLine("Press 3 for display all departments data.");

            int? details = Convert.ToInt32(Console.ReadLine());
            if (details == null)
            {
                throw new ArgumentNullException();
            }
            switch (details)
            {
                case 1:

                    // department details for the department Id. 

                    Console.WriteLine("\n Department details for the department Id.....\n ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    if (id <= 0)
                    {
                        throw new InvalidDataException();
                    }
                    if (id == null)
                    {
                        throw new ArgumentNullException();
                    }
                    var deptId = service.GetDepartments(id);
                    service.CheckData(deptId);
                    Console.WriteLine();
                    break;

                case 2:

                    //Department details for the Department Name

                    Console.WriteLine("\n Department details for the Department Name.....\n");
                    string name = Console.ReadLine();
                    if (name == null)
                    {
                        throw new ArgumentNullException();
                    }
                    var depName = service.GetDepartments(deptName: name);
                    service.CheckData(depName);
                    Console.WriteLine();
                    break;

                case 3:

                    // Get the all department data

                    var deptData = service.GetDepartments();
                    Console.WriteLine("\n Get the all department data.....\n");
                    service.CheckData(deptData);
                    Console.WriteLine();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Please enter 1 to 3 ");
                    break;
            }
        }

        // Project Data
        public void ProjectDetails()
        {
            Console.WriteLine("Press 1 for get the list of projects there for the department id.");
            Console.WriteLine("Press 2 for get list of projects there for the department name");
            Console.WriteLine("Press 3 for get all projects for each department.");

            int? details = Convert.ToInt32(Console.ReadLine());
            if (details == null)
            {
                throw new ArgumentNullException();
            }
            switch (details)
            {
                case 1:

                    // The list of projects there for the department Id

                    Console.WriteLine("\n The list of projects there for the department Id.....\n");
                    int? proId = Convert.ToInt32(Console.ReadLine());
                    if (proId <= 0)
                    {
                        throw new InvalidDataException();
                    }
                    if (proId == null)
                    {
                        throw new ArgumentNullException();
                    }
                    var projectdeptId = service.GetProjects(proId);
                    service.CheckData(projectdeptId);
                    Console.WriteLine();
                    break;

                case 2:

                    // The list of projects there for the Department Name

                    Console.WriteLine("\n The list of projects there for the Department Name.....\n");
                    string proName = Console.ReadLine();
                    if (proName == null)
                    {
                        throw new ArgumentNullException();
                    }
                    var projectdeptName = service.GetProjects(departmentName: proName);
                    service.CheckData(projectdeptName);
                    Console.WriteLine();
                    break;

                case 3:

                    // Get the all Project Data

                    var projectData = service.GetProjects();
                    Console.WriteLine("\n Get the all Project Data.....\n");
                    service.CheckData(projectData);
                    Console.WriteLine();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Please enter 1 to 3 ");
                    break;
            }
        }

        // Employee Data
        public void EmployeeDetails()
        {
            Console.WriteLine("Press 1 for get the list of employees's there for the department id.");
            Console.WriteLine("Press 2 for get the employee's details for the employee id.");
            Console.WriteLine("Press 3 for get all employee's data");

            int? details = Convert.ToInt32(Console.ReadLine());
            if (details == null)
            {
                throw new ArgumentNullException();
            }
            switch (details)
            {
                case 1:

                    // The list of employees there for the department Id

                    Console.WriteLine("\n The list of employees there for the department Id.....\n");
                    int? deptId = Convert.ToInt32(Console.ReadLine());
                    if (deptId <= 0)
                    {
                        throw new InvalidDataException();
                    }
                    if (deptId == null)
                    {
                        throw new ArgumentNullException();
                    }
                    var deptid = service.GetEmployees(deptId);
                    service.CheckData(deptid);
                    break;

                case 2:

                    // The employees details for the Employee Id

                    Console.WriteLine("\n The employees details for the Employee Id.....\n");
                    int? empNumber = Convert.ToInt32(Console.ReadLine());
                    if (empNumber <= 0)
                    {
                        throw new InvalidDataException();
                    }
                    if (empNumber == null)
                    {
                        throw new ArgumentNullException();
                    }
                    var empid = service.GetEmployees(empNum: empNumber);
                    service.CheckData(empid);
                    Console.WriteLine();
                    break;

                case 3:

                    // Get all the employee data

                    var GetEmployees = service.GetEmployees();
                    Console.WriteLine("\n Get the all employee Data.....\n");
                    service.CheckData(GetEmployees);
                    Console.WriteLine();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Please enter 1 to 3 ");
                    break;
            }
        }

        // The number of employees working for each department
        public void EmployeeCount()
        {
            var employeecount = service.EmployeeCount();
            Console.WriteLine("\n The number of employees working for each department.....\n");
            foreach (var employee in employeecount)
            {
                Console.WriteLine(employee.ToString());
            }
            Console.WriteLine();
        }

        // The total salary paid for each department
        public void EmployeeSumSalary()
        {
            var empsalary = service.EmployeeSalary();
            Console.WriteLine("\n The total salary paid for each department.....\n");
            foreach (var emp in empsalary)
            {
                Console.WriteLine(emp.ToString());
            }
            Console.WriteLine();
        }

        // Add a property Name to Assignment enitity 
        public void PropertyName()
        {
            var names = service.GetAllNames();
            Console.WriteLine("\n DepartmentName, ProjectName, AssignmentName, EmployeeName.....\n");
            service.CheckData(names);
            Console.WriteLine();
        }

        // Searching Data
        public void SearchingData()
        {
            Console.WriteLine("press 1 for get department id that you want data. (Please enter department id.)");
            Console.WriteLine("Press 2 for get department name that you want data. (Please enter department name.)");
            Console.WriteLine("Press 3 for Search Data.");
            int? details = Convert.ToInt32(Console.ReadLine());
            if (details == null)
            {
                throw new ArgumentNullException();
            }
            switch (details)
            {
                case 1:

                    //  Result by department wise by using department Id

                    Console.WriteLine("\n Enter Department Id.....\n");
                    int? dataByDeptId = Convert.ToInt32(Console.ReadLine());
                    if (dataByDeptId <= 0)
                    {
                        throw new InvalidDataException();
                    }
                    if (dataByDeptId == null)
                    {
                        throw new ArgumentNullException();
                    }
                    var deptmentid = service.GetCombineData(deptId: dataByDeptId);
                    service.CheckData(deptmentid);
                    break;

                case 2:

                    // Result by department wise by using department Name

                    Console.WriteLine("\n Enter any Department Name.....\n");
                    string? dataByDeptName = Console.ReadLine();
                    if (string.IsNullOrEmpty(dataByDeptName))
                    {
                        throw new ArgumentNullException("Enter vaild Department Name");
                    }
                    var deptName = service.GetCombineData(deptName: dataByDeptName);
                    service.CheckData(deptName);
                    break;

                case 3:
                    // Searching result by text

                    Console.WriteLine("\n Enter any Data.......");
                    string? searchingData = Console.ReadLine();
                    if (string.IsNullOrEmpty(searchingData))
                    {
                        throw new ArgumentNullException("There is no search data found..");
                    }
                    var searching = service.GetSearchingData(deptName: searchingData);
                    service.CheckData(searching);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Please enter 1 to 3 ");
                    break;
            }
        }
        public void AssignmentDetails()
        {
            // Assignment Data

            var ass = service.GetAssignments();
            Console.WriteLine("Get the all Assinment Data.....");
            Console.WriteLine();
            service.CheckData(ass);
            Console.WriteLine();
        }
    }
}
