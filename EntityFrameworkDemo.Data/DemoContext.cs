using EntityFrameworkDemo.Data.Seeder;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Data;

public class DemoContext : DbContext
{
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