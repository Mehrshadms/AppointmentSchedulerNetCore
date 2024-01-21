using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace AppointmentScheduler.Contract.Appointment;

public class PostPoneAppointment
{
    public long Id { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    [MaxLength(1024)]
    public string PostPoneReason { get; set; }
}