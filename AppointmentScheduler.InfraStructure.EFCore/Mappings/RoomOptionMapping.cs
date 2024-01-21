using AppointmentScheduler.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.InfraStructure.EFCore.Mappings;

public class RoomOptionMapping : IEntityTypeConfiguration<RoomOption>
{
    public void Configure(EntityTypeBuilder<RoomOption> builder)
    {
        builder.ToTable("RoomOptions");
        builder.Property(x => x.HaveOption).IsRequired();

        builder.HasOne(x => x.Option)
            .WithMany(x => x.RoomOptions)
            .HasForeignKey(x => x.OptionId);
        
        builder.HasOne(x => x.Room)
            .WithMany(x => x.RoomOptionsList)
            .HasForeignKey(x => x.RoomId);

    }
}