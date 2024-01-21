using Framework.Domain;

namespace AppointmentScheduler.Domain.Room;

public class Option : EntityBase
{
    public string StringOption { get; private set; }
    public List<RoomOption> RoomOptions { get; private set; }

    public Option()
    {
        RoomOptions = new List<RoomOption>();
    }

    public Option(string stringOption)
    {
        StringOption = stringOption;
    }
    
    public void Edit(string stringOption)
    {
        StringOption = stringOption;
    }
}