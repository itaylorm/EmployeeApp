using iMaxwell.Common.Models;

namespace iMaxwell.Common.Data;

public interface IDepartmentDataService
{
    Task<int> CreateDepartment(IDepartmentModel department);
    Task<List<IDepartmentModel>?> GetDepartments();
}