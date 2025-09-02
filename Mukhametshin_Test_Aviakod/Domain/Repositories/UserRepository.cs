using Microsoft.EntityFrameworkCore;
using Mukhametshin_Test_Aviakod.DataAccess;
using Mukhametshin_Test_Aviakod.Domain.Entities;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;

namespace Mukhametshin_Test_Aviakod.Domain.Repositories;

public class UserRepository(DataContext db) : IUserRepository
{
    public Task<User?> GetByUsername(string userName, CancellationToken ct)
    {
        return db.Users.FirstOrDefaultAsync(u => u.Username == userName, ct);
    }


    public async Task<User> Add(User user, CancellationToken ct)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync(ct);
        return user;
    }
}