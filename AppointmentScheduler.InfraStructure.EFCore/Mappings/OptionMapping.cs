using AppointmentScheduler.Domain.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.InfraStructure.EFCore.Mappings;

public class OptionMapping : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable("Options");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StringOption).HasMaxLength(1024).IsRequired();

        builder.HasMany(x => x.RoomOptions)
            .WithOne(x => x.Option)
            .HasForeignKey(x => x.OptionId);
    }
}