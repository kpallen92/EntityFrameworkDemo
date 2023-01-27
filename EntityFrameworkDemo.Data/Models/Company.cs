using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Data.Models;

public class Company
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CompanyId { get; set; }
    
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    public int? YearFounded { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool Inactive { get; set; }
    
    [Required]
    public DateTimeOffset CreatedOn { get; set; }

    // public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}