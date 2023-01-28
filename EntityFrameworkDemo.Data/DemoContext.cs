using EntityFrameworkDemo.Data.Models;
using EntityFrameworkDemo.Data.Seeder;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Data;

public class DemoContext : DbContext
{
    public DbSet<Company> Company => Set<Company>();
    // public DbSet<Employee> Employee => Set<Employee>();
    
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        new CompanyRoleSeeder(modelBuilder).Seed();
    }
}