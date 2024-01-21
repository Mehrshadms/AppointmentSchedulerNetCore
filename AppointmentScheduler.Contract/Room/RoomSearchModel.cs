namespace AppointmentScheduler.Contract.Room;

public class RoomSearchModel
{
    public string Name { get; set; }
    public int LeastCapacity { get; set; }
    public bool IsVirtual { get; set; }
}