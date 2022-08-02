namespace ProjectManagement.Core.Model
{
    public class ProjectResourceDetails
    {
        public string? DepartmentName { get; set; }
        public string? ProjectName { get; set; }
        public string? AssignmentName { get; set; }
        public string? EmployeeName { get; set; }

        public override string? ToString()
        {
            return ($"{DepartmentName} {ProjectName} {AssignmentName} {EmployeeName}");
        }
    }
}
