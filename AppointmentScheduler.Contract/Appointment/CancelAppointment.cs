using System.ComponentModel.DataAnnotations;
using Framework.Application;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Contract.Appointment;

public class CancelAppointment
{
    public long Id { get; set; }
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    [MaxLength(1024)]
    public string CancellationReason { get; set; }
}