namespace AccountManagement.Contract.Employee;

public class EmployeeViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RoleName { get; set; }
    public bool IsRemoved { get; set; }
}