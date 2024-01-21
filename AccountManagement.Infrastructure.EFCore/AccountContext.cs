using AccountManagement.Domain.Employee;
using AccountManagement.Domain.Role;
using AccountManagement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore;

public class AccountContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public AccountContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}