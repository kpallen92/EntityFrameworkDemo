using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Data.Models;
using EntityFrameworkDemo.Domain.Models;

namespace EntityFrameworkDemo.Domain.Services;

public class EmployeeService : BaseService
{
    public EmployeeService(DemoContext context) : base(context)
    {
    }

    public async Task<EmployeeDto?> CreateAsync(EmployeeDto employeeDto)
    {
        var employee = new Employee();
        ParseToDataModel(employeeDto, ref employee);

        await CreateAsync(employee);

        return await GetAsync(employee.EmployeeId);
    }

    public async Task<bool> DeleteAsync(int employeeId)
    {
        Employee? employee = await GetAsync<Employee>(employeeId);

        if (employee == null)
            return false;

        await DeleteAsync(employee);

        return true;
    }

    public async Task<EmployeeDto?> GetAsync(int employeeId)
    {
        Employee? employee = await GetAsync<Employee>(employeeId);

        return employee == null ? null : ParseToDto(employee);
    }

    public async Task<EmployeeDto?> UpdateAsync(EmployeeDto employeeDto)
    {
        Employee? employee = await GetAsync<Employee>(employeeDto.EmployeeId.GetValueOrDefault());

        if (employee == null)
            return null;

        ParseToDataModel(employeeDto, ref employee);

        await Context.SaveChangesAsync();

        return await GetAsync(employee.EmployeeId);
    }

    private static void ParseToDataModel(EmployeeDto employeeDto, ref Employee employee)
    {
        employee.EmployeeId = employeeDto.EmployeeId.GetValueOrDefault();
        employee.FirstName = employeeDto.FirstName;
        employee.LastName = employeeDto.LastName;
        employee.CompanyRoleId = employeeDto.CompanyRoleId;
        employee.CompanyId = employeeDto.CompanyId;
    }

    private static EmployeeDto ParseToDto(Employee employee)
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