using EntityFrameworkDemo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : Controller
{
    private readonly Domain.Services.EmployeeService _employeeService;

    public EmployeeController(Domain.Services.EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(EmployeeDto employeeDto)
    {
        return Ok(await _employeeService.CreateAsync(employeeDto));
    }
}