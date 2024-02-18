using _0_Framework.Application.Accounts.Password;
using AccountManagement.Application;
using AccountManagement.Application.Abstractions;
using AccountManagement.Configuration.Authentication;
using AccountManagement.Configuration.OptionSetup.JWT;
using AccountManagement.Contract.Employee;
using AccountManagement.Contract.Role;
using AccountManagement.Domain.Employee;
using AccountManagement.Domain.Role;
using AccountManagement.Infrastructure.EFCore;
using AccountManagement.Infrastructure.EFCore.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AccountManagement.Configuration;

public static class AccountManagementBootstrapper
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IRoleApplication, RoleApplication>();

        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IEmployeeApplication, EmployeeApplication>();

        services.AddTransient<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IJwtProvider,JwtProvider>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.ConfigureOptions<JwtOptionSetup>();
        services.ConfigureOptions<JwtBearerOptionSetup>();

        services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
    }
}