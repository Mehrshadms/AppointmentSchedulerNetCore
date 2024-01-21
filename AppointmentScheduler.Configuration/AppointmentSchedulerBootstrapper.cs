using AppointmentScheduler.Application;
using AppointmentScheduler.Contract.Appointment;
using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.Room;
using AppointmentScheduler.Contract.RoomOption;
using AppointmentScheduler.Domain.Appointment;
using AppointmentScheduler.Domain.Room;
using AppointmentScheduler.InfraStructure.EFCore;
using AppointmentScheduler.InfraStructure.EFCore.Repositories;
using AppointmentSchedulerQuery.Contracts.Appointments;
using AppointmentSchedulerQuery.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentScheduler.Configuration;

public class AppointmentSchedulerBootstrapper
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IOptionApplication,OptionApplication>();
        services.AddTransient<IOptionRepository, OptionRepository>();

        services.AddTransient<IRoomApplication, RoomApplication>();
        services.AddTransient<IRoomRepository, RoomRepository>();
        
        services.AddTransient<IRoomOptionRepository, RoomOptionRepository>();

        services.AddTransient<IAppointmentApplication, AppointmentApplication>();
        services.AddTransient<IAppointmentRepository, AppointmentRepository>();

        services.AddTransient<IAppointmentQuery, AppointmentQuery>();
        
        services.AddDbContext<AppointmentContext>(x => x.UseSqlServer(connectionString));
    }

}