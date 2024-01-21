using Framework.Domain;

namespace AppointmentScheduler.Domain.Room;

public class RoomOption : EntityBase
{
    public long OptionId { get; private set; }
    public Option Option { get; private set; }
    public long RoomId { get; private set; }
    public Room Room { get; private set; }
    public bool HaveOption { get; private set; }

    public RoomOption(long optionId, long roomId)
    {
        OptionId = optionId;
        RoomId = roomId;
        HaveOption = false;
    }

    public void MakeTrue()
    {
        HaveOption = true;
    }
    public void MakeFalse()
    {
        HaveOption = false;
    }
}