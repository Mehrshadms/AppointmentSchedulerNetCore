using AccountManagement.Contract.Role;
using AccountManagement.Domain.Role;
using Framework.Application;

namespace AccountManagement.Application;

public class RoleApplication : IRoleApplication
{
    private readonly IRoleRepository _roleRepository;

    public RoleApplication(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public OperationResult Create(CreateRole command)
    {
        OperationResult operationResult = new();
        if (_roleRepository.Exists(x => x.Name == command.Name))
            operationResult.Failed(ApplicationMessages.RecordDuplication);

        Role role = new Role(command.Name);
        
        _roleRepository.Create(role);
        _roleRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Edit(EditRole command)
    {
        OperationResult operationResult = new();

        Role role = _roleRepository.Get(command.Id);
        if (role is null)
            operationResult.Failed(ApplicationMessages.RecordNotFound);
        
        if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            operationResult.Failed(ApplicationMessages.RecordDuplication);

        role.Edit(command.Name);
        
        _roleRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public List<RoleViewModel> GetRoles()
    {
        return _roleRepository.GetRoles();
    }
}