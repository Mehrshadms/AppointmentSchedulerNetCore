using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace AppointmentScheduler.Contract.Appointment;

public class RescheduleAppointment
{
    public long Id { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    public string NewStartDateTime { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    public string NewEndDateTime { get; set; } 
}