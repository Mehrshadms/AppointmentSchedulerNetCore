using _0_Framework.Application.Accounts.Password;
using AccountManagement.Application.Abstractions;
using AccountManagement.Contract.Employee;
using AccountManagement.Domain.Employee;
using Framework.Application;

namespace AccountManagement.Application;

public class EmployeeApplication : IEmployeeApplication
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public EmployeeApplication(IEmployeeRepository employeeRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _employeeRepository = employeeRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public OperationResult Create(CreateEmployee command)
    {
        OperationResult operationResult = new();
        
        if (command.Password.Length < 8)
            return operationResult.Failed();
        
        if (_employeeRepository.Exists(x => x.FirstName == command.FirstName && x.LastName == command.LastName))
            return operationResult.Failed(ApplicationMessages.RecordDuplication);
        
        //Hash
        string password = command.Password;
        
        Employee employee = new Employee(command.FirstName, command.LastName, command.Email,password,command.RoleId,command.PhoneNumber);
        _employeeRepository.Create(employee);
        _employeeRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Edit(EditEmployee command)
    {
        OperationResult operationResult = new();
        Employee employee = _employeeRepository.Get(command.Id);
        if (employee is null)
            return operationResult.Failed(ApplicationMessages.RecordNotFound);
        
        if (_employeeRepository
            .Exists(x => x.FirstName == command.FirstName && x.LastName == command.LastName && x.Id != command.Id))
            return operationResult.Failed(ApplicationMessages.RecordDuplication);
        
        employee.Edit(command.FirstName, command.LastName,command.RoleId,command.PhoneNumber);
        
        _employeeRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Login(EmployeeLogin command)
    {
        OperationResult operationResult = new();
        //Get
        Employee employee = _employeeRepository.GetBy(command.Username);
        if (employee is null)
            return operationResult.Failed(ApplicationMessages.RecordNotFound);

        //Evaluate
        var result = _passwordHasher.Check(employee.Password, command.Password);
        if (result.Verified is false)
            return operationResult.Failed();

        //CreateJWT&Return
        string token = _jwtProvider.Generate(employee);



        return operationResult.Succeeded();
    }

    public OperationResult ChangePassword(ChangePassword command)
    {
        OperationResult operationResult = new();

        if (command.Password.Length < 8)
            return operationResult.Failed();
        
        if (command.Password != command.RePassword)
            return operationResult.Failed();
        
        Employee employee = _employeeRepository.Get(command.Id);
        
        if (employee is null)
            return operationResult.Failed(ApplicationMessages.RecordNotFound);

        //Hash
        string password = command.Password;
        
        employee.ChangePassword(password);
        _employeeRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public List<EmployeeViewModel> Search(EmployeeSearchModel searchModel)
    {
        return _employeeRepository.Search(searchModel);
    }

    public OperationResult Remove(long id)
    {
        OperationResult operationResult = new();
        Employee employee = _employeeRepository.Get(id);
        if (employee is null)
           return operationResult.Failed(ApplicationMessages.RecordNotFound);
        
        employee.Remove();
        _employeeRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Restore(long id)
    {
        OperationResult operationResult = new();
        Employee employee = _employeeRepository.Get(id);
        if (employee is null)
            return operationResult.Failed(ApplicationMessages.RecordNotFound);
        
        employee.Restore();
        _employeeRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public void Logout()
    {
        throw new NotImplementedException();
    }

    public EditEmployee GetDetail(long id)
    {
        return _employeeRepository.GetDetail(id);
    }
}