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

        // modelBuilder.Entity<Employee>(entity =>
        // {
        //     entity.HasKey(prop => prop.EmployeeId);
        //     entity.Property(prop => prop.EmployeeId).HasColumnType("bigint");
        //     entity.Property(prop => prop.FirstName).HasMaxLength(100).IsRequired();
        //     entity.Property(prop => prop.LastName).HasMaxLength(100).IsRequired();
        //     entity.Property(prop => prop.CreatedOn).IsRequired();
        // });
        //
        // new CompanyRoleSeeder(modelBuilder).Seed();
    }
}