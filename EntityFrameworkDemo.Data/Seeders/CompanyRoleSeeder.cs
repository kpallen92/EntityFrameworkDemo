using EntityFrameworkDemo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Data.Seeders;

public class CompanyRoleSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public CompanyRoleSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<CompanyRole>().HasData(
            new CompanyRole {CompanyRoleId = 1, Description = "Employee"},
            new CompanyRole {CompanyRoleId = 2, Description = "Manager / Leader"},
            new CompanyRole {CompanyRoleId = 3, Description = "Owner / Partner"},
            new CompanyRole {CompanyRoleId = 4, Description = "Other"}
        );
    }
}