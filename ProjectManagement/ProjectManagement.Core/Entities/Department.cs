﻿namespace ProjectManagement.Core.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public ulong PhoneNumber { get; set; }
        public override string? ToString()
        {
            return ($"{DepartmentId}\t {DepartmentName}\t {PhoneNumber}");
        }
    }
}
