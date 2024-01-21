using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.RoomOption;

namespace AppointmentScheduler.Contract.Room;

public class RoomViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public bool IsRemoved { get; set; }
    public bool IsVirtual { get; set; }
    public List<RoomOptionViewModel> RoomOptions { get; set; }
}