using System.Globalization;
using AppointmentScheduler.InfraStructure.EFCore;
using AppointmentSchedulerQuery.Contracts.Appointments;
using Framework.Application.Utility;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulerQuery.Queries;

public class AppointmentQuery : IAppointmentQuery
{
    private readonly AppointmentContext _context;

    public AppointmentQuery(AppointmentContext context)
    {
        _context = context;
    }

    public List<AppointmentQueryModel> GetOngoingAppointments()
    {
        return _context.Appointments.AsNoTracking()
            .Where(x=>x.StartDateTime < DateTime.Now && x.EndDateTime > DateTime.Now)
            .Select(x => new AppointmentQueryModel
        {
            Id = x.Id,
            Title = x.Title,
            Cancelled = x.Cancelled,
            PostPoned = x.Postponed,
            StartDateTime = x.StartDateTime.ToFarsiFull(),
            EndDateTime = x.EndDateTime.ToFarsiFull()
        }).ToList();
    }
    
    public List<AppointmentQueryModel> GetFutureAppointments()
    {
        return _context.Appointments.AsNoTracking()
            .Where(x=>x.StartDateTime > DateTime.Now)
            .Select(x => new AppointmentQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Cancelled = x.Cancelled,
                PostPoned = x.Postponed,
                StartDateTime = x.StartDateTime.ToFarsiFull(),
                EndDateTime = x.EndDateTime.ToFarsiFull()
            }).ToList();
    }
    
    public List<AppointmentQueryModel> GetSpecificDateTimeAppointments(string dateTime)
    {
        DateTime specifiedStart = dateTime.ToGeorgianDateTimeSpecificDayStart();
        DateTime specifiedEnd = specifiedStart.ToGeorgianDateTimeSpecificDayStart();
        return _context.Appointments.AsNoTracking()
            .Where(x=>x.StartDateTime > specifiedStart && x.EndDateTime < specifiedEnd)
            .Select(x => new AppointmentQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Cancelled = x.Cancelled,
                PostPoned = x.Postponed,
                StartDateTime = x.StartDateTime.ToFarsiFull(),
                EndDateTime = x.EndDateTime.ToFarsiFull()
            }).ToList();
    }

    public List<AppointmentQueryModel> GetFinishedAppointments()
    {
        return _context.Appointments.AsNoTracking()
            .Where(x=>x.EndDateTime < DateTime.Now)
            .Select(x => new AppointmentQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Cancelled = x.Cancelled,
                PostPoned = x.Postponed,
                StartDateTime = x.StartDateTime.ToFarsiFull(),
                EndDateTime = x.EndDateTime.ToFarsiFull()
            }).ToList();
    }


    public AppointmentDetailQueryModel GetAppointmentDetail(long id)
    {
        return _context.Appointments.AsNoTracking().Include(x => x.Room).Select(x => new AppointmentDetailQueryModel
        {
            Id = x.Id,
            Title = x.Title,
            Cancelled = x.Cancelled,
            PostPoned = x.Postponed,
            StartDateTime = x.StartDateTime.ToFarsiFull(),
            EndDateTime = x.EndDateTime.ToFarsiFull(),
            Description = x.Description,
            NotificationMessage = x.NotificationMessage,
            CancellationReason = x.CancellationReason,
            PostponedDescription = x.PostponedDescription,
            RoomName = x.Room.Name
        }).FirstOrDefault(x => x.Id == id);
    }
}