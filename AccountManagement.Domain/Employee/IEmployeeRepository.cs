using AccountManagement.Contract.Employee;
using Framework.Domain;

namespace AccountManagement.Domain.Employee;

public interface IEmployeeRepository : IRepository<long,Employee>
{
    EditEmployee GetDetail(long id);
    List<EmployeeViewModel> Search(EmployeeSearchModel searchModel);
    Employee GetBy(string username);
}