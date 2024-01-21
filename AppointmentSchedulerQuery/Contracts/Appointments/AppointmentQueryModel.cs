namespace AppointmentSchedulerQuery.Contracts.Appointments;

public class AppointmentQueryModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string StartDateTime { get; set; }
    public string EndDateTime { get; set; }
    public bool Cancelled { get; set; }
    public bool PostPoned { get; set; }
}

public class AppointmentDetailQueryModel : AppointmentQueryModel
{
    public string PostponedDescription { get; set; }
    public string CancellationReason { get; set; }
    public string? NotificationMessage { get; set; }
    public string Description { get; set; }
    public string RoomName { get; set; }
}