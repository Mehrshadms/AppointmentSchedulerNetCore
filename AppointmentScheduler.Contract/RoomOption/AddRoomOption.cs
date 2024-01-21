namespace AppointmentScheduler.Contract.RoomOption;

public class AddRoomOption
{
    public long OptionId { get; set; }
    public string StringOption { get; set; }
    public bool HaveOption { get; set; }
    public long RoomId { get; set; }
}