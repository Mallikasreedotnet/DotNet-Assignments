namespace ProjectManagement.Core.Entities
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string? EmployeeName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DepartmentId { get; set; }
        public ulong Phone { get; set; }
        public string? Email { get; set; }
        public int Salary { get; set; }
        public override string? ToString()
        {
            return ($"{EmployeeNumber}\t {EmployeeName}\t {FirstName}\t {LastName}\t {DepartmentId}\t {Phone}\t {Email}\t {Salary}");
        }

    }

}
