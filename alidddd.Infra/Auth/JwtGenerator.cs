using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using alidddd.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace alidddd.Infra.Auth;

public class JwtGenerator:IJwtGenerator
{
    private readonly JwtSettings _set;

    public JwtGenerator(IOptions<JwtSettings> jwt)
    {
        _set = jwt.Value;
    }

    public string GenerateToke(Guid Id, string email)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Sid, Id.ToString()),

        };
        var securityToke = new JwtSecurityToken(
            issuer: _set.Issuer,
            expires: DateTime.Now.AddHours(_set.Expires),
            claims:claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_set.Secret)),
                    SecurityAlgorithms.HmacSha256)
                );

        return new JwtSecurityTokenHandler().WriteToken(securityToke);
    }
}