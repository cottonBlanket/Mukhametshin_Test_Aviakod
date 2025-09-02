using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Mukhametshin_Test_Aviakod.Services.Auth.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Mukhametshin_Test_Aviakod.Options;

namespace Mukhametshin_Test_Aviakod.Services.Auth;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtOptions _opt;

    public JwtTokenService(IOptions<JwtOptions> options)
    {
        _opt = options.Value;
    }


    public string GenerateToken(string userId, string userName)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId),
            new(JwtRegisteredClaimNames.UniqueName, userName)
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opt.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: _opt.Issuer,
            audience: _opt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: creds);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}