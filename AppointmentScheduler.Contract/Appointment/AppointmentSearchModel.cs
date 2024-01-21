namespace AppointmentScheduler.Contract.Appointment;

public class AppointmentSearchModel
{
    public string Title { get; set; }
    public string StartDateTime { get; set; }
    public string EndDateTime { get; set; }
    public long RoomId { get; set; }
}