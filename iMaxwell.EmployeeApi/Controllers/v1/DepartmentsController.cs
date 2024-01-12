using Asp.Versioning;
using iMaxwell.Common.Data;
using iMaxwell.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace iMaxwell.EmployeeApi.Controllers.v1;

[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class DepartmentsController : ControllerBase
{
    private readonly ILogger<DepartmentsController> _log;
    private readonly IDepartmentDataService _data;

    public DepartmentsController(ILogger<DepartmentsController> log, IDepartmentDataService data)
    {
        _log = log;
        _data = data;
    }

    // GET api/v1/Departments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentModel>>> Get()
    {
        try
        {
            _log.LogInformation("GET: api/v1/Departments");
            var departments = await _data.GetDepartments();
            return Ok(departments);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "The GET call to api/v1/Departments failed");
            return BadRequest();
        }
    }

    // POST api/v1/Departments
    [HttpPost]
    public async Task<ActionResult<DepartmentModel>> Post([FromBody] DepartmentModel department)
    {
        try
        {
            _log.LogInformation("POST: api/v1/Departments {Department}", department);
            int id = await _data.CreateDepartment(department);
            department.Id = id;
            return Ok(department);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "The POST call to api/v1/Departments failed. The value was {Department}", department);
            return BadRequest();
        }

    }

}
