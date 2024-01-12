using iMaxwell.Common.DataAccess;
using iMaxwell.Common.Models;
using Microsoft.Extensions.Logging;

namespace iMaxwell.Common.Data;

public class DepartmentDataService : IDepartmentDataService
{
    private const string ConnectionStringName = "Default";

    private readonly ILogger<DepartmentDataService> _log;
    private readonly IDataAccess _sql;

    public DepartmentDataService(IDataAccess sql, ILogger<DepartmentDataService> log)
    {
        _log = log;
        _sql = sql;
    }

    public async Task<List<IDepartmentModel>?> GetDepartments()
    {
        var departments = await _sql.LoadDataAsync<DepartmentModel, dynamic>("dbo.spDepartments_GetAll",
            new { }, ConnectionStringName); ;
        if (departments != null)
        {
            return departments.ToList<IDepartmentModel>();
        }
        else
        {
            _log.LogError("Unable to retrieve departments");
            return null;
        }
    }

    public async Task<int> CreateDepartment(IDepartmentModel department)
    {
        int id = await _sql.AddDataAsync("dbo.spEmployees_Create",
            new { Id = -1, department.Name }, "Id", ConnectionStringName);
        if (id != -1)
        {
            _log.LogInformation("Added Department: {Department} with id {Id}", department.ToString(), id);
        }
        else
        {
            _log.LogError("Failed to add {Department}", department.ToString());
        }
        return id;
    }
}
