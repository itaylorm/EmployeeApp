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
        int id = await _sql.AddDataAsync("dbo.spEmployees_Create",
            new
            {
                Id = -1,
                employee.FirstName,
                employee.LastName,
                employee.Title,
                employee.DepartmentId,
                employee.HireDate,
                employee.Salary,
                employee.IsCurrent,
                employee.ExitDate
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
        await _sql.SaveDataAsync("dbo.spEmployees_Exit", new { Id = id }, ConnectionStringName);
    }

    public async Task UpdateEmployeeSalary(int id, double salary)
    {
        await _sql.SaveDataAsync("dbo.spEmployees_UpdateSalary", new { Id = id, Salary = salary }, ConnectionStringName);
    }
}
