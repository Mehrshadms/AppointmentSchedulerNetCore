using AppointmentScheduler.Contract.Appointment;
using AppointmentScheduler.Domain.Appointment;
using Framework.Application.Utility;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.InfraStructure.EFCore.Repositories;

public class AppointmentRepository : RepositoryBase<long,Appointment>,IAppointmentRepository
{
    private readonly AppointmentContext _context;
    public AppointmentRepository(AppointmentContext context) : base(context)
    {
        _context = context;
    }

    public EditAppointment GetDetail(long id)
    {
        return _context.Appointments.Select(x => new EditAppointment
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            NotificationMessage = x.NotificationMessage,
            RoomId = x.RoomId,
            StartDateTime = x.StartDateTime.ToFarsiFull(),
            EndDateTime = x.EndDateTime.ToFarsiFull()
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<AppointmentViewModel> Search(AppointmentSearchModel searchModel)
    {
        var query = _context.Appointments.Include(x => x.Room).Select(x => new AppointmentViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            NotificationMessage = x.NotificationMessage,
            Cancelled = x.Cancelled,
            PostPoned = x.Postponed,
            RoomName = x.Room.Name,
            StartDateTime = x.StartDateTime,
            EndDateTime = x.EndDateTime,
            StartDateTimeShow = x.StartDateTime.ToFarsiFull(),
            EndDateTimeShow = x.EndDateTime.ToFarsiFull()
        });
        
        if(!string.IsNullOrWhiteSpace(searchModel.Title))
            query = query.Where(x=>x.Title.Contains(searchModel.Title));
        
        if (!string.IsNullOrWhiteSpace(searchModel.StartDateTime))
        {
            DateTime startDate = searchModel.StartDateTime.ToGeorgianDateTimeFull();
            query = query.Where(x => x.StartDateTime > startDate);
        }
        
        if (!string.IsNullOrWhiteSpace(searchModel.EndDateTime))
        {
            DateTime endDate = searchModel.EndDateTime.ToGeorgianDateTimeFull();
            query = query.Where(x => x.StartDateTime < endDate);
        }
        
        
        return query.OrderByDescending(x => x.Id).ToList();
    }

    public List<Appointment> GetListForDateValidation(long roomId)
    {
        return _context.Appointments
            .Where(x => x.RoomId == roomId && x.Cancelled==false && x.Postponed==false)
            .OrderBy(x => x.StartDateTime)
            .ToList();
    }
}