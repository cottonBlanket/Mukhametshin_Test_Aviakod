namespace Mukhametshin_Test_Aviakod.Services.Auth.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string hash, string password);
}