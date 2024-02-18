using AppointmentScheduler.Domain.Appointment;
using Framework.Domain;

namespace AccountManagement.Domain.Employee;

public class Employee : EntityBase
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool IsRemoved { get; private set; }
    public int RoleId { get; private set; }
    public Role.Role Role { get; private set; }
    public List<AppointmentEmployee> AppointmentEmployees { get; set; }

    public Employee(string firstName, string lastName, string email, string password, int roleId, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        RoleId = roleId;
        PhoneNumber = phoneNumber;
        IsRemoved = false;
    }

    public void Edit(string firstName, string lastName,int roleId, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        RoleId = roleId;
        PhoneNumber = phoneNumber;
    }

    public void ChangePassword(string password)
    {
        Password = password;
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