namespace ProjectManagement.Infrastructure.Services
{
    public class ServiceValidations
    {
        ProjectManagementService service = new ProjectManagementService();
        bool valid = false;
        // Department Data
        public void DepartmentDetails()
        {
            try
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
                        do
                        {
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
                            if (deptId.Any())
                            {
                                service.CheckData(deptId);
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }

                        } while (valid);
                        break;

                    case 2:

                        //Department details for the Department Name
                        do
                        {
                            Console.WriteLine("\n Department details for the Department Name.....\n");
                            string name = Console.ReadLine();
                            if (name == null)
                            {
                                throw new ArgumentNullException();
                            }
                            var depName = service.GetDepartments(deptName: name);
                            if (depName.Any())
                            {
                                service.CheckData(depName);
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }
                        } while (valid);
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
            catch (InvalidDataException a)
            {
                Console.WriteLine(a.Message);
                DepartmentDetails();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                DepartmentDetails();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                DepartmentDetails();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                DepartmentDetails();
            }
            catch (Exception ex)
            {
                DepartmentDetails();
            }
        }

        // Project Data
        public void ProjectDetails()
        {
            try
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
                        do
                        {
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
                            if (projectdeptId.Any())
                            {
                                service.CheckData(projectdeptId);
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }
                        } while (valid);
                        break;

                    case 2:

                        // The list of projects there for the Department Name
                        do
                        {
                            Console.WriteLine("\n The list of projects there for the Department Name.....\n");
                            string proName = Console.ReadLine();
                            if (proName == null)
                            {
                                throw new ArgumentNullException();
                            }
                            var projectdeptName = service.GetProjects(departmentName: proName);
                            if (projectdeptName.Any())
                            {
                                service.CheckData(projectdeptName);
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }
                        } while (valid);
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
            catch (InvalidDataException a)
            {
                Console.WriteLine(a.Message);
                ProjectDetails();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                ProjectDetails();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                ProjectDetails();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ProjectDetails();
            }
            catch (Exception ex)
            {
                ProjectDetails();
            }
        }

        // Employee Data
        public void EmployeeDetails()
        {
            try
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
                        do
                        {
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
                            if (deptid.Any())
                            {
                                service.CheckData(deptid);
                                valid = false;

                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }

                        } while (valid);
                        break;

                    case 2:

                        // The employees details for the Employee Id
                        do
                        {
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
                            if (empid.Any())
                            {
                                service.CheckData(empid);
                                valid = false;

                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }
                        } while (valid);
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
            catch (InvalidDataException a)
            {
                Console.WriteLine(a.Message);
                EmployeeDetails();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                EmployeeDetails();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                EmployeeDetails();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                EmployeeDetails();
            }
            catch (Exception ex)
            {
                EmployeeDetails();
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
            try
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
                        do
                        {
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
                            if (deptmentid.Any())
                            {
                                service.CheckData(deptmentid);
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }
                        } while (valid);
                        break;

                    case 2:

                        // Result by department wise by using department Name
                        do
                        {
                            Console.WriteLine("\n Enter any Department Name.....\n");
                            string? dataByDeptName = Console.ReadLine();
                            if (string.IsNullOrEmpty(dataByDeptName))
                            {
                                throw new ArgumentNullException("Enter vaild Department Name");
                            }
                            var deptName = service.GetCombineData(deptName: dataByDeptName);
                            if (deptName.Any())
                            {
                                service.CheckData(deptName);
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }
                        } while (valid);
                        break;

                    case 3:
                        // Searching result by text
                        do
                        {
                            Console.WriteLine("\n Enter any Data.......");
                            string? searchingData = Console.ReadLine();
                            if (string.IsNullOrEmpty(searchingData))
                            {
                                throw new ArgumentNullException("There is no search data found..");
                            }
                            var searching = service.GetSearchingData(deptName: searchingData);
                            if (searching.Any())
                            {
                                service.CheckData(searching);
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Data not found please enteer valid data");
                                valid = true;
                            }
                        } while (valid);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Please enter 1 to 3 ");
                        break;
                }
            }
            catch (InvalidDataException a)
            {
                Console.WriteLine(a.Message);
                SearchingData();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                SearchingData();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                SearchingData();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                SearchingData();
            }
            catch (Exception ex)
            {
                SearchingData();
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
