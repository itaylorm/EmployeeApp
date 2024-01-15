
namespace iMaxwell.Common.Models
{
    public interface IEmployeeModel
    {
        int Id { get; set; }

        int DepartmentId { get; set; }
        DateTime? ExitDate { get; set; }
        string? FirstName { get; set; }
        DateTime HireDate { get; set; }
        bool IsCurrent { get; set; }
        string? LastName { get; set; }
        int? ManagerId { get; set; }
        double? Salary { get; set; }
        string? Title { get; set; }
    }
}