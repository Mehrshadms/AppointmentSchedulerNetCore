using AppointmentScheduler.Contract.Appointment;
using AppointmentScheduler.Domain.Appointment;
using Framework.Application;
using Framework.Application.Utility;

namespace AppointmentScheduler.Application;

public class AppointmentApplication : IAppointmentApplication
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentApplication(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    private OperationResult IsDateTimeValid(DateTime start, DateTime end,long roomId)
    {
        OperationResult operationResult = new();
        
        if (start > end || start < DateTime.Now)
            return operationResult.Failed(ApplicationMessages.DateTimeInvalid);

        List<Appointment> appointments = _appointmentRepository.GetListForDateValidation(roomId);
        if (appointments.Count != 0)
        {
            var result = appointments.Exists(x =>
                (Math.Max(x.StartDateTime.ToBinary(), start.ToBinary()) <
                 Math.Min(x.EndDateTime.ToBinary(), end.ToBinary())));
            if (result==false)
                return operationResult.Failed(ApplicationMessages.DateTimeConflict);
        }
        
        return operationResult.Succeeded();
    }

    public OperationResult Define(DefineAppointment command)
    {
        OperationResult operationResult = new();
        DateTime startDate = command.StartDateTime.ToGeorgianDateTimeFull();
        DateTime endDate = command.EndDateTime.ToGeorgianDateTimeFull();

        operationResult = IsDateTimeValid(startDate, endDate,command.RoomId);
        
        if (operationResult.IsSucceeded)
        {
            Appointment appointment = new Appointment(command.Title, startDate,endDate,
                command.NotificationMessage, command.Description, command.RoomId);
        
            _appointmentRepository.Create(appointment);
            _appointmentRepository.SaveChanges();
        }
        
        return operationResult;
    }

    public OperationResult Edit(EditAppointment command)
    {
        OperationResult operationResult = new();
        Appointment appointment = _appointmentRepository.Get(command.Id);
        
        if (appointment == null)
            operationResult.Failed(ApplicationMessages.RecordNotFound);

        appointment.Edit(command.Title, command.NotificationMessage, command.Description, command.RoomId);
        
        _appointmentRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult PostPone(PostPoneAppointment command)
    {
        OperationResult operationResult = new();
        Appointment appointment = _appointmentRepository.Get(command.Id);
        
        if (appointment == null)
            operationResult.Failed(ApplicationMessages.RecordNotFound);
        
        appointment.Postpone(command.PostPoneReason);
        _appointmentRepository.SaveChanges();
        
        return operationResult.Succeeded();
    }

    public OperationResult Cancel(CancelAppointment command)
    {
        OperationResult operationResult = new();
        Appointment appointment = _appointmentRepository.Get(command.Id);
        
        if (appointment == null)
            operationResult.Failed(ApplicationMessages.RecordNotFound);
        
        appointment.Cancel(command.CancellationReason);
        _appointmentRepository.SaveChanges();

        return operationResult.Succeeded();
    }

    public OperationResult Reschedule(RescheduleAppointment command)
    {
        OperationResult operationResult = new();
        Appointment appointment = _appointmentRepository.Get(command.Id);
        
        if (appointment == null)
            operationResult.Failed(ApplicationMessages.RecordNotFound);
        
        DateTime startDate = command.NewStartDateTime.ToGeorgianDateTimeFull();
        DateTime endDate = command.NewEndDateTime.ToGeorgianDateTimeFull();

        if (startDate > endDate || startDate < DateTime.Now)
            operationResult.Failed(ApplicationMessages.DateTimeInvalid);
        
        
        appointment.Reschedule(startDate,endDate);
        _appointmentRepository.SaveChanges();
        //TODO notificationCall?
        return operationResult.Succeeded();
    }

    public EditAppointment GetDetail(long id)
    {
        return _appointmentRepository.GetDetail(id);
    }

    public List<AppointmentViewModel> Search(AppointmentSearchModel searchModel)
    {
        return _appointmentRepository.Search(searchModel);
    }
}