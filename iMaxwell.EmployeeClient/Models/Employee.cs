﻿using iMaxwell.Common.Models;
using System;

namespace iMaxwell.EmployeeClient.Models
{
    public record class Employee : IEmployeeModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Title { get; set; }

        public double? Salary { get; set; }

        public string SalaryAsCurrency() => Salary.HasValue && Salary > 0 ? $"{Salary.Value.ToString("C")}/yr" : "Unknown";

        public int? ManagerId { get; set; }

        public int DepartmentId { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public bool IsCurrent { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} FirstName:{FirstName} LastName:{LastName} Title:{Title} Salary:{Salary} " +
                $"ManagerId:{ManagerId} DepartmentId:{DepartmentId} " +
                $"HireDate:{HireDate} ExitDate:{ExitDate} IsCurrent:{IsCurrent}";
        }
    }
}
