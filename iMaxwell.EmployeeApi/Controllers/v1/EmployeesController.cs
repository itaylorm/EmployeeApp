using Asp.Versioning;
using iMaxwell.Common.Data;
using iMaxwell.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace iMaxwell.EmployeeApi.Controllers.v1;

[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _log;
    private readonly IEmployeeDataService _data;

    public EmployeesController(ILogger<EmployeesController> log, IEmployeeDataService data)
    {
        _log = log;
        _data = data;
    }

    // GET api/v1/Employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> Get()
    {
        try
        {
            _log.LogInformation("GET: api/v1/Employees");
            var employees = await _data.GetEmployees();
            return Ok(employees);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "The GET call to api/v1/Employees failed");
            return BadRequest();
        }
    }

    // GET api/v1/Employees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeModel>> Get(int id)
    {
        try
        {
            _log.LogInformation("GET: api/v1/Employees/{Id}", id);
            var employee = await _data.GetEmployeeById(id);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "The GET call to api/v1/Employees/Id failed. The Id was {Id}.", id);
            return BadRequest();
        }
    }

    // POST api/v1/Employees
    [HttpPost]
    public async Task<ActionResult<EmployeeModel>> Post([FromBody] EmployeeModel employee)
    {
        try
        {
            _log.LogInformation("POST: api/Employees {Employee}", employee);
            int id = await _data.CreateEmployee(employee);
            employee.Id = id;
            return Ok(employee);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "The POST call to api/Employees failed. The value was {Employee}", employee);
            return BadRequest();
        }

    }

    // PUT api/v1/Employees/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeModel employee)
    {
        try
        {
            _log.LogInformation("PUT: api/v1/employees/{id} {Employee}", id , employee);
            await _data.UpdateEmployee(employee);
            return Ok();
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "The PUT call to api/v1/Employees/{Id}/ failed. The value was {Employee}", id, employee);
            return BadRequest();
        }
    }

    // PUT api/v1/Employees/5/Exit
    [HttpPut("{id}/Exit")]
    public async Task<IActionResult> Exit(int id)
    {
        try
        {
            _log.LogInformation("PUT: api/v1/employees/{id}/exit", id);
            await _data.ExitEmployee(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "The PUT call to api/v1/employees/{Id}/exit failed.", id);
            return BadRequest();
        }
    }
}
