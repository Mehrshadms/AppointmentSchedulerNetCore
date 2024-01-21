using AppointmentScheduler.Domain.Appointment;
using AppointmentScheduler.Domain.Room;
using AppointmentScheduler.InfraStructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.InfraStructure.EFCore;

public class AppointmentContext : DbContext
{
    public DbSet<Option> Options { get; set; }
    public DbSet<RoomOption> RoomOptions { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(OptionMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}