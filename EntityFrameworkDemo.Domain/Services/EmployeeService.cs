using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Data.Models;
using EntityFrameworkDemo.Domain.Models;

namespace EntityFrameworkDemo.Domain.Services;

public class EmployeeService
{
    private readonly DemoContext _context;
    
    public EmployeeService(DemoContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto?> CreateAsync(EmployeeDto employeeDto)
    {
        var employee = new Employee();
        ParseToDataModel(employeeDto, ref employee);

        _context.Add(employee);
        await _context.SaveChangesAsync();

        return ParseToDto(employee);
    }

    private static void ParseToDataModel(EmployeeDto employeeDto, ref Employee employee)
    {
        employee.EmployeeId = employeeDto.EmployeeId.GetValueOrDefault();
        employee.FirstName = employeeDto.FirstName;
        employee.LastName = employeeDto.LastName;
        employee.CompanyRoleId = employeeDto.CompanyRoleId;
        employee.CompanyId = employeeDto.CompanyId;
    }

    public static EmployeeDto ParseToDto(Employee employee)
    {
        return new EmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            CompanyRoleId = employee.CompanyRoleId,
            CompanyId = employee.CompanyId
        };
    }
}