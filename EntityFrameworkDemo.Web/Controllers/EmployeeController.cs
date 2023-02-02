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
    
    [HttpDelete("Delete/{employeeId:int}")]
    public async Task<IActionResult> DeleteAsync(int employeeId)
    {
        return Ok(await _employeeService.DeleteAsync(employeeId));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(EmployeeDto employeeDto)
    {
        return Ok(await _employeeService.UpdateAsync(employeeDto));
    }
}