using AccountManagement.Contract.Role;
using AccountManagement.Domain.Role;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repositories;

public class RoleRepository : RepositoryBase<long,Role>, IRoleRepository
{
    private readonly AccountContext _context;
    public RoleRepository(AccountContext context) : base(context)
    {
        _context = context;
    }

    public EditRole GetDetail(long id)
    {
        throw new NotImplementedException();
    }

    public List<RoleViewModel> GetRoles()
    {
        throw new NotImplementedException();
    }
}