using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Mukhametshin_Test_Aviakod.Services.Auth.Interfaces;

namespace Mukhametshin_Test_Aviakod.Services.Auth;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100_000,
            numBytesRequested: 32));

        return $"{Convert.ToBase64String(salt)}.{hashed}";
    }

    public bool Verify(string hash, string password)
    {
        var parts = hash.Split('.');
        if (parts.Length != 2) return false;

        var salt = Convert.FromBase64String(parts[0]);
        var expectedHash = parts[1];

        string actualHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100_000,
            numBytesRequested: 32));

        return expectedHash == actualHash;
    }
}