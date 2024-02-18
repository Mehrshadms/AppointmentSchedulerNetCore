using Framework.Domain;

namespace AppointmentScheduler.Domain.Appointment;

public interface IAppointmentEmployeeRepository : IRepository<long,AppointmentEmployee>
{
    Task CreateMultiple(List<AppointmentEmployee> commands);
    List<AppointmentEmployee> GetListBy(long appointmentId);
}