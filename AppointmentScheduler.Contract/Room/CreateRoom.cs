using System.ComponentModel.DataAnnotations;
using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.RoomOption;
using Framework.Application;

namespace AppointmentScheduler.Contract.Room;

public class CreateRoom
{
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    [MaxLength(256)]
    public string Name { get; set; }
    [MaxLength(1024)]
    public string? Description { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    public int Capacity { get; set; }
    [MaxLength(1024)]
    public string? LinkToVirtualRoom { get; set; }
    public bool IsVirtual { get; set; }
    public List<AddRoomOption> AddRoomOptions { get; set; }
    public List<long> SelectedOptions { get; set; }
}