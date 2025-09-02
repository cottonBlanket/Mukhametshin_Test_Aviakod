using MediatR;
using Mukhametshin_Test_Aviakod.Domain.Entities;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;
using Mukhametshin_Test_Aviakod.Services.Auth.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Login.Commands.RegisterUser;

using static RegisterUser;

public class RegisterUserHandler : IRequestHandler<Command, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(Command request, CancellationToken ct)
    {
        var existing = await _userRepository.GetByUsername(request.UserName, ct);
        if (existing != null)
        {
            throw new Exception("Пользователь уже существует");
        }

        var user = new User
        {
            Username = request.UserName,
            PasswordHash = _passwordHasher.Hash(request.Password)
        };

        await _userRepository.Add(user, ct);
        return user.Id;
    }
}