using Framework.Domain;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Domain.Room;

public class Room : EntityBase
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int Capacity { get; private set; }
    public string? LinkToVirtualRoom { get; private set; }
    public bool IsVirtual { get; private set; }
    public bool IsRemoved { get; private set; }
    public List<RoomOption> RoomOptionsList { get; private set; }
    public List<Appointment.Appointment> Appointments { get; private set; }

    public Room()
    {
        RoomOptionsList = new List<RoomOption>();
        Appointments = new List<Appointment.Appointment>();
    }

    public Room(string name, string? description, int capacity, string? linkToVirtualRoom, bool isVirtual)
    {
        Name = name;
        Description = description;
        Capacity = capacity;
        LinkToVirtualRoom = linkToVirtualRoom;
        IsVirtual = isVirtual;
        IsRemoved = false;
    }

    public void Edit(string name, string? description, int capacity, string? linkToVirtualRoom, bool isVirtual)
    {
        Name = name;
        Description = description;
        Capacity = capacity;
        LinkToVirtualRoom = linkToVirtualRoom;
        IsVirtual = isVirtual;
    }

    public void Remove()
    {
        IsRemoved = true;
    }
    public void Restore()
    {
        IsRemoved = true;
    }
}