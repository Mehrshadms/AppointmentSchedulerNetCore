using Framework.Domain;

namespace AccountManagement.Domain.Employee;

public class Employee : EntityBase
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string PhoneNumber { get; private set; }
    public int RoleId { get; private set; }
    public Role.Role Role { get; private set; }

    public Employee(string firstName, string lastName, string email, string password, int roleId, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        RoleId = roleId;
        PhoneNumber = phoneNumber;
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
}