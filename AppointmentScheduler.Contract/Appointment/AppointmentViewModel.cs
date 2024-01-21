namespace AppointmentScheduler.Contract.Appointment;

public class AppointmentViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string StartDateTimeShow { get; set; }
    public string EndDateTimeShow { get; set; }
    public bool Cancelled { get; set; }
    public bool PostPoned { get; set; }
    public string? NotificationMessage { get; set; }
    public string Description { get; set; }
    public string RoomName { get; set; }
}