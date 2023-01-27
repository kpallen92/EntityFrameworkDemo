using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Domain.Models;

public class EmployeeDto
{
    [Range(1, int.MaxValue)]
    public int? EmployeeId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue)]
    public int CompanyRoleId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int CompanyId { get; set; }
}