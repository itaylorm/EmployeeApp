using iMaxwell.Common.Models;

namespace iMaxwell.Common.Data;

public interface IEmployeeDataService
{
    Task<int> CreateEmployee(IEmployeeModel employee);
    Task ExitEmployee(int id);
    Task<IEmployeeModel?> GetEmployeeById(int id);
    Task<List<IEmployeeModel>?> GetEmployees();
    Task UpdateEmployee(EmployeeModel employee);
}