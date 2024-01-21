namespace AppointmentSchedulerQuery.Contracts.Appointments;

public interface IAppointmentQuery
{
    List<AppointmentQueryModel> GetOngoingAppointments();
    List<AppointmentQueryModel> GetFutureAppointments();
    List<AppointmentQueryModel> GetFinishedAppointments();
    List<AppointmentQueryModel> GetSpecificDateTimeAppointments(string dateTime);
    
    AppointmentDetailQueryModel GetAppointmentDetail(long id);
}