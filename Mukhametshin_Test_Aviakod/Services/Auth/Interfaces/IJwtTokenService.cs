namespace Mukhametshin_Test_Aviakod.Services.Auth.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(string userId, string userName);
}