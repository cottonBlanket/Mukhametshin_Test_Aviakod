using Mukhametshin_Test_Aviakod.Domain.Entities;

namespace Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsername(string userName, CancellationToken ct);
    Task<User> Add(User user, CancellationToken ct);
}
