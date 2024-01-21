using Framework.Application;

namespace AccountManagement.Contract.Employee;

public interface IEmployeeApplication
{
    OperationResult Create(CreateEmployee command);
    OperationResult Edit(EditEmployee command);
    OperationResult Login(EmployeeLogin command);
    OperationResult ChangePassword(ChangePassword command);
    List<EmployeeViewModel> Search(EmployeeSearchModel searchModel);
    
    void Logout();
    EditEmployee GetDetail(long id);
}