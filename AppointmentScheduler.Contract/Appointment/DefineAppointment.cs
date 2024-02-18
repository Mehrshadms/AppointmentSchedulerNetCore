using System.ComponentModel.DataAnnotations;
using AccountManagement.Contract.Employee;
using AccountManagement.Contract.Role;
using AppointmentScheduler.Contract.Room;
using Framework.Application;

namespace AppointmentScheduler.Contract.Appointment;

public class DefineAppointment
{
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    [MaxLength(256)]
    public string Title { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    public string StartDateTime { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    public string EndDateTime { get; set; }
    [MaxLength(2048)]
    public string? NotificationMessage { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    [MaxLength(1024)]
    public string Description { get; set; }

    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    [Range(1, int.MaxValue)]
    public bool IsForAllEmployees { get; set; }
    
    public List<RoomViewModel> AvailableRooms { get; set; }
    public long RoomId { get; set; }
    
    public List<EmployeeViewModel> AvailableEmployee { get; set; }
    public List<RoleViewModel> AvailableRoles { get; set; }
    
    public List<long> ParticipantEmployees { get; set; }
    public List<int> ParticipantRoles { get; set; }
}