using AppointmentScheduler.Domain.Appointment;
using AppointmentScheduler.Domain.Room;
using AppointmentScheduler.InfraStructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;
using AppointmentEmployee = AppointmentScheduler.Domain.Appointment.AppointmentEmployee;

namespace AppointmentScheduler.InfraStructure.EFCore;

public class AppointmentContext : DbContext
{
    public DbSet<Option> Options { get; set; }
    public DbSet<RoomOption> RoomOptions { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentEmployee> AppointmentEmployees { get; set; }

    public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(OptionMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        // modelBuilder.Entity<AppointmentEmployee>();
        base.OnModelCreating(modelBuilder);
    }
}