using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AccountManagement.Application.Abstractions;
using AccountManagement.Domain.Employee;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AccountManagement.Configuration.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(Employee employee)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,employee.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,employee.Email),
            new Claim(JwtRegisteredClaimNames.GivenName,employee.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName,employee.LastName),
            new Claim("roleId",employee.RoleId.ToString())
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey))
            ,SecurityAlgorithms.Sha256); 
        
        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.Now.AddHours(6),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            
            return token.ToString();
    }
}