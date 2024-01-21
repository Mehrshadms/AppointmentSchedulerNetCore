using AccountManagement.Domain.Employee;

namespace AccountManagement.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(Employee employee);
}