using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Data.Models;
using EntityFrameworkDemo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Domain.Services;

public class CompanyService
{
    private readonly DemoContext _context;
    
    public CompanyService(DemoContext context)
    {
        _context = context;
    }

    public async Task<CompanyDto?> CreateAsync(CompanyDto companyDto)
    {
        var company = new Company();
        ParseToDataModel(companyDto, ref company);

        _context.Add(company);
        await _context.SaveChangesAsync();

        return ParseToDto(company);
    }

    public async Task<CompanyDto?> GetAsync(int companyId)
    {
        Company? company = await _context
            .Company
            .AsNoTracking()
            // .Include(x => x.Employees)
            .FirstOrDefaultAsync(x => x.CompanyId == companyId);
        
        return company == null ? null : ParseToDto(company);
    }

    public async Task<CompanyDto?> UpdateAsync(CompanyDto companyDto)
    {
        Company? company = await _context.FindAsync<Company>(companyDto.CompanyId.GetValueOrDefault());

        if (company == null)
            return null;

        ParseToDataModel(companyDto, ref company);

        await _context.SaveChangesAsync();

        return ParseToDto(company);
    }

    private static void ParseToDataModel(CompanyDto companyDto, ref Company company)
    {
        company.CompanyId = companyDto.CompanyId.GetValueOrDefault();
        company.CompanyName = companyDto.CompanyName;
        company.YearFounded = companyDto.YearFounded;
        company.Description = companyDto.Description;
        company.Inactive = companyDto.Inactive;
    }

    private static CompanyDto ParseToDto(Company company)
    {
        return new CompanyDto
        {
            // Employees = company.Employees.Select(EmployeeService.ParseToDto).ToList(),
            CompanyId = company.CompanyId,
            CompanyName = company.CompanyName,
            YearFounded = company.YearFounded,
            Description = company.Description,
            Inactive = company.Inactive,
        };
    }
}