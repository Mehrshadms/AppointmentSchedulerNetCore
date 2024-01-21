using AppointmentScheduler.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.InfraStructure.EFCore.Mappings;

public class RoomMapping : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1024).IsRequired(false);
        builder.Property(x => x.LinkToVirtualRoom).HasMaxLength(1024).IsRequired(false);
        builder.Property(x => x.IsVirtual).IsRequired();
        builder.Property(x => x.Capacity).IsRequired();


        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Room)
            .HasForeignKey(x => x.RoomId);
        
        builder.HasMany(x => x.RoomOptionsList)
            .WithOne(x => x.Room)
            .HasForeignKey(x => x.RoomId);
        
    }
}