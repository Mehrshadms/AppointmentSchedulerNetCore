using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AccountManagement.Application.Abstractions;
using AccountManagement.Domain.Employee;
using Microsoft.IdentityModel.Tokens;

namespace AccountManagement.Configuration.Authentication;

public class JwtProvider : IJwtProvider
{
    public string Generate(Employee employee)
    {
        var claims = new Claim[]
        {

        };

        //var SigningCredentials = new SigningCredentials(new SymmetricSecurityKey()); 
        
        var token = new JwtSecurityToken(
            "issuer",
            "audience",
            claims,
            null,
            DateTime.Now.AddHours(6),
            null);

        
            
            return token.ToString();
    }
}