using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Data.Models;

public class Company
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CompanyId { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string CompanyName { get; set; } = string.Empty;

    public int? YearFounded { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Description { get; set; }

    [Required]
    public bool Inactive { get; set; }
    
    [Required]
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}