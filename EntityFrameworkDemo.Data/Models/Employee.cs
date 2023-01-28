namespace EntityFrameworkDemo.Data.Models;

public class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public int CompanyRoleId { get; set; }
    public CompanyRole? CompanyRole { get; set; }
    
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    
    public DateTimeOffset CreatedOn { get; set; }
}