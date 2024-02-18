using AccountManagement.Domain.Employee;
using AccountManagement.Domain.Role;
using AppointmentScheduler.Domain.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.InfraStructure.EFCore.Mappings;

public class AppointmentEmployee : IEntityTypeConfiguration<Domain.Appointment.AppointmentEmployee>
{
    public void Configure(EntityTypeBuilder<Domain.Appointment.AppointmentEmployee> builder)
    {
        builder.ToTable("AppointmentEmployees");

        builder.HasKey(x => x.Id);

        // builder.HasOne(x => x.Appointment)
        //     .WithMany(x => x.AppointmentEmployees)
        //     .HasForeignKey(x => x.AppointmentId);

        // builder.HasOne(x => x.Employee)
        //     .WithMany()
        //     .HasForeignKey(x => x.EmployeeId)
        //     .IsRequired(false);
        //
        // builder.HasOne(x => x.Role)
        //     .WithMany()
        //     .HasForeignKey(x => x.RoleId)
        //     .IsRequired(false);


        builder.HasOne<Appointment>()
            .WithMany(x => x.AppointmentEmployees)
            .HasForeignKey(x => x.AppointmentId)
            .IsRequired();
        
         builder.HasOne<Employee>()
            .WithMany(x => x.AppointmentEmployees)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
         builder.HasOne<Role>()
            .WithMany(x => x.AppointmentEmployees)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}