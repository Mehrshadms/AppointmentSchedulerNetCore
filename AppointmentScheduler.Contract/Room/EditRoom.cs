using AppointmentScheduler.Contract.RoomOption;

namespace AppointmentScheduler.Contract.Room;

public class EditRoom : CreateRoom
{
    public long Id { get; set; }
    public List<EditRoomOption> EditRoomOptions { get; set; }
}