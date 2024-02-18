using Framework.Domain;

namespace AppointmentScheduler.Domain.Appointment;

public class Appointment : EntityBase
{
    public string Title { get; private set; }
    public bool IsForAllEmployees { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public string? NotificationMessage { get; private set; }
    public bool Postponed { get; private set; }
    public string PostponedDescription { get; private set; }
    public DateTime OldStartDateTime { get; private set; }
    public DateTime OldEndDateTime { get; private set; }
    public string Description { get; private set; }
    public bool Cancelled { get; private set; }
    public string CancellationReason { get; private set; }
    public long RoomId { get; private set; }
    public Room.Room Room { get; private set; }
    public List<AppointmentEmployee> AppointmentEmployees { get; set; }
    

    public Appointment(string title, DateTime startDateTime, DateTime endDateTime, string? notificationMessage, string description, long roomId, bool isForAllEmployees)
    {
        Title = title;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        NotificationMessage = notificationMessage;
        Description = description;
        RoomId = roomId;
        IsForAllEmployees = isForAllEmployees;
        Cancelled = false;
        Postponed = false;
    }
    
    public void Edit(string title, string? notificationMessage, string description, long roomId, bool isForAllEmployees)
    {
        Title = title;
        NotificationMessage = notificationMessage;
        Description = description;
        RoomId = roomId;
        IsForAllEmployees = isForAllEmployees;
        Cancelled = false;
        Postponed = false;
    }

    public void Postpone(string postponedDescription)
    {
        Postponed = true;
        PostponedDescription = postponedDescription;
    }

    public void Reschedule(DateTime newStartTime,DateTime newEndTime)
    {
        Postponed = false;
        OldStartDateTime = StartDateTime;
        OldEndDateTime = EndDateTime;
        StartDateTime = newStartTime;
        EndDateTime = newEndTime;
    }

    public void Cancel(string cancellationReason)
    {
        Cancelled = true;
        CancellationReason = cancellationReason;
    }
}