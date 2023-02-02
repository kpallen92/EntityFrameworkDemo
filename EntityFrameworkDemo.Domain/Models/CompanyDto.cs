using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using EntityFrameworkDemo.Data.Models;

namespace EntityFrameworkDemo.Domain.Models;

public class CompanyDto
{
    [Range(1, int.MaxValue)]
    public int? CompanyId { get; set; }
    
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int? YearFounded { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool Inactive { get; set; }
    
    // public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}