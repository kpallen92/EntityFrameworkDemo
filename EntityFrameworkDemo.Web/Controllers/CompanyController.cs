using EntityFrameworkDemo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : Controller
{
    private readonly Domain.Services.CompanyService _companyService;

    public CompanyController(Domain.Services.CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CompanyDto companyDto)
    {
        return Ok(await _companyService.CreateAsync(companyDto));
    }

    [HttpGet("Get/{companyId:int}")]
    public async Task<IActionResult> GetAsync(int companyId)
    {
        return Ok(await _companyService.GetAsync(companyId));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(CompanyDto companyDto)
    {
        return Ok(await _companyService.UpdateAsync(companyDto));
    }
}