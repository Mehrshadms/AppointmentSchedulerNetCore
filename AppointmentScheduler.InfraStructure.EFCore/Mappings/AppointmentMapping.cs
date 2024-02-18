using AppointmentScheduler.Domain.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.InfraStructure.EFCore.Mappings;

public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");
        builder.HasKey(x=>x.Id);

        builder.Property(x => x.Title).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1024).IsRequired(false);
        builder.Property(x => x.NotificationMessage).HasMaxLength(2048).IsRequired(false);
        builder.Property(x => x.CancellationReason).HasMaxLength(1024).IsRequired(false);
        builder.Property(x => x.PostponedDescription).HasMaxLength(1024).IsRequired(false);
        
        builder.HasOne(x => x.Room)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.RoomId);

        builder.HasMany(x => x.AppointmentEmployees)
            .WithOne()
            .HasForeignKey(x => x.AppointmentId)
            .IsRequired();
    }
}