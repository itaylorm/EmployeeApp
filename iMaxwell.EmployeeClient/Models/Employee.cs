using iMaxwell.Common.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iMaxwell.EmployeeClient.Models
{
    public record class Employee : IEmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [MinLength(5, ErrorMessage = "The first name is not long enough")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        [DisplayName("Last Name")]
        [MinLength(5, ErrorMessage = "The last name is not long enough")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "The Title is required")]
        [DisplayName("Title")]
        [MinLength(5, ErrorMessage = "The title is not long enough")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The Yearly Salary is required")]
        [DisplayName("Yearly Salary")]
        public double? Salary { get; set; }

        public string SalaryAsCurrency() => Salary.HasValue && Salary > 0 ? $"{Salary.Value.ToString("C")}/yr" : "Unknown";

        public int? ManagerId { get; set; }

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The Hire Date is required")]
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; } = DateTime.UtcNow;

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
