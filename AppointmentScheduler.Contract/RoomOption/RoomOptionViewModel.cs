namespace AppointmentScheduler.Contract.RoomOption;

public class RoomOptionViewModel
{
    public long Id { get; set; }
    public long OptionId { get; set; }
    public string StringOption { get; set; }
    public bool HaveOption { get; set; }
    public long RoomId { get; set; }
}