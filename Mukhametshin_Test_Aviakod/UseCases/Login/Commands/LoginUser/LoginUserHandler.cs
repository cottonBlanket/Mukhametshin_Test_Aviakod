using MediatR;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;
using Mukhametshin_Test_Aviakod.Services.Auth.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Login.Commands.LoginUser;

using static LoginUser;

public class LoginUserHandler : IRequestHandler<Command, string?>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginUserHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService
    )
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string?> Handle(Command request, CancellationToken ct)
    {
        var user = await _userRepository.GetByUsername(request.UserName, ct);
        if (user is null)
        {
            return null;
        }

        if (_passwordHasher.Verify(user.PasswordHash, request.Password) == false)
        {
            return null;
        }

        var token = _jwtTokenService.GenerateToken(user.Id.ToString(), user.Username);
        return token;
    }
}