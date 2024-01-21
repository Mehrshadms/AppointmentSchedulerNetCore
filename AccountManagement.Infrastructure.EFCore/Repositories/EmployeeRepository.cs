using AccountManagement.Contract.Employee;
using AccountManagement.Domain.Employee;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repositories;

public class EmployeeRepository : RepositoryBase<long,Employee>, IEmployeeRepository
{
    private readonly AccountContext _context;

    public EmployeeRepository(AccountContext context) : base(context)
    {
        _context = context;
    }

    public EditEmployee GetDetail(long id)
    {
        throw new NotImplementedException();
    }

    public List<EmployeeViewModel> Search(EmployeeSearchModel searchModel)
    {
        throw new NotImplementedException();
    }

    public Employee GetBy(string username)
    {
        return _context.Employees.FirstOrDefault(x => x.Email == username);
    }
}