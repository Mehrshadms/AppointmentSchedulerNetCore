using Framework.Application;

namespace AppointmentScheduler.Contract.Appointment;

public interface IAppointmentApplication
{
    OperationResult Define(DefineAppointment command);
    OperationResult Edit(EditAppointment command);
    OperationResult PostPone(PostPoneAppointment command);
    OperationResult Cancel(CancelAppointment command);
    OperationResult Reschedule(RescheduleAppointment command);
    EditAppointment GetDetail(long id);
    List<AppointmentViewModel> Search(AppointmentSearchModel searchModel);
    
}