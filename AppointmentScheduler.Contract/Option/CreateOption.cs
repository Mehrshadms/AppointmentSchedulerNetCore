using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Framework.Application;

namespace AppointmentScheduler.Contract.Option;

public class CreateOption
{
    [Required(ErrorMessage = ValidationMessages.FieldRequired)]
    [MaxLength(1024)]
    public string StringOption { get; set; }
}