using Framework.Domain;

namespace AppointmentScheduler.Domain.Appointment;

public class AppointmentEmployee : EntityBase
{
    public long AppointmentId { get; private set; }
    public long? EmployeeId { get; private set; }
    public bool IsRoleBased { get; private set; }
    public int? RoleId { get; private set; }
    public bool IsRemoved { get; private set; }
    public bool DidParticipate { get; private set; }

    public AppointmentEmployee()
    {
        DidParticipate = false;
        IsRemoved = false;
    }

    public AppointmentEmployee(long appointmentId,long employeeId)
    {
        AppointmentId = appointmentId;
        EmployeeId = employeeId;
        IsRoleBased = false;
    }
    
    public AppointmentEmployee(long appointmentId,int roleId)
    {
        AppointmentId = appointmentId;
        RoleId = roleId;
        IsRoleBased = true;
    }

    public void Participated()
    {
        DidParticipate = true;
    }

    public void Remove()
    {
        IsRemoved = true;
    }
    
    public void Restore()
    {
        IsRemoved = false;
    }
    
}