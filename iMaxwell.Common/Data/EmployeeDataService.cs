using iMaxwell.Common.DataAccess;
using iMaxwell.Common.Models;
using Microsoft.Extensions.Logging;

namespace iMaxwell.Common.Data;

public class EmployeeDataService : IEmployeeDataService
{
    private const string ConnectionStringName = "Default";

    private readonly ILogger<EmployeeDataService> _log;
    private readonly IDataAccess _sql;

    public EmployeeDataService(IDataAccess sql, ILogger<EmployeeDataService> log)
    {
        _log = log;
        _sql = sql;
    }

    public async Task<List<IEmployeeModel>?> GetEmployees()
    {
        var employees = await _sql.LoadDataAsync<EmployeeModel, dynamic>("dbo.spEmployees_GetAll",
            new {  }, ConnectionStringName); ;
        if (employees != null)
        {
            return employees.ToList<IEmployeeModel>();
        }
        else
        {
            _log.LogError("Unable to retrieve employees");
            return null;
        }
    }

    public async Task<IEmployeeModel?> GetEmployeeById(int id)
    {
        var employees = await _sql.LoadDataAsync<EmployeeModel, dynamic>("dbo.spEmployees_GetById",
            new { Id = id }, ConnectionStringName); ;
        if (employees != null)
        {
            return employees.FirstOrDefault<IEmployeeModel>();
        }
        else
        {
            _log.LogError("Unable to retrieve employee for {Id}", id);
            return null;
        }
    }

    public async Task<int> CreateEmployee(IEmployeeModel employee)
    {
        if(employee.FirstName == "string") throw new ArgumentException("First Name is required", nameof(employee.FirstName));
        if(employee.LastName == "string") throw new ArgumentException("Last Name is required", nameof(employee.LastName));
        if(employee.Title == "string") throw new ArgumentException("Title is required", nameof(employee.Title));
        if(employee.DepartmentId == 0) throw new ArgumentException("Department is required", nameof(employee.DepartmentId));
        if(employee.ManagerId == 0) throw new ArgumentException("Manager is required", nameof(employee.ManagerId));

        int id = await _sql.AddDataAsync("dbo.spEmployees_Create",
            new
            {
                Id = -1,
                employee.FirstName,
                employee.LastName,
                employee.Title,
                employee.DepartmentId,
                employee.ManagerId,
                employee.HireDate,
                employee.Salary,
            }, "Id", ConnectionStringName);
        if (id != -1)
        {
            _log.LogInformation("Added Employee: {Employee} with id {Id}", employee.ToString(), id);
        }
        else
        {
            _log.LogError("Failed to add {Employee}", employee.ToString());
        }
        return id;
    }

    public async Task ExitEmployee(int id)
    {
        await _sql.SaveDataAsync("dbo.spEmployees_Exit", new { Id = id, ExitDate = DateTime.UtcNow }, ConnectionStringName);
    }

    public async Task UpdateEmployeeSalary(int id, double salary)
    {
        await _sql.SaveDataAsync("dbo.spEmployees_UpdateSalary", new { Id = id, Salary = salary }, ConnectionStringName);
    }
}
