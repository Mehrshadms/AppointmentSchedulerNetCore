using Framework.Application;

namespace AccountManagement.Contract.Role;

public interface IRoleApplication
{
    OperationResult Create(CreateRole command);
    OperationResult Edit(EditRole command);
    List<RoleViewModel> GetRoles();
}