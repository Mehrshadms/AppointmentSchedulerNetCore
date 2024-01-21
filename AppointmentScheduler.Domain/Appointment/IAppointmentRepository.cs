using AppointmentScheduler.Contract.Appointment;
using Framework.Domain;

namespace AppointmentScheduler.Domain.Appointment;

public interface IAppointmentRepository : IRepository<long,Appointment>
{
    EditAppointment GetDetail(long id);
    List<AppointmentViewModel> Search(AppointmentSearchModel searchModel);
    List<Appointment> GetListForDateValidation(long roomId);
}