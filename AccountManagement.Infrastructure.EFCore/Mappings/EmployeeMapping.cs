using AccountManagement.Domain.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(70).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(70).IsRequired();
        builder.Property(x => x.RoleId).IsRequired();

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.RoleId);

        builder.HasMany(x => x.AppointmentEmployees)
            .WithOne()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}