using AppointmentScheduler.Domain.Appointment;

namespace AccountManagement.Domain.Role;

public class Role 
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Employee.Employee> Employees { get; private set; }
    public List<AppointmentEmployee> AppointmentEmployees { get; set; }

    public Role(string name)
    {
        Name = name;
    }
    
    public void Edit(string name)
    {
        Name = name;
    }
}