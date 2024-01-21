using AccountManagement.Contract.Role;
using Framework.Domain;

namespace AccountManagement.Domain.Role;

public interface IRoleRepository : IRepository<long,Role>
{
    EditRole GetDetail(long id);
    List<RoleViewModel> GetRoles();
}