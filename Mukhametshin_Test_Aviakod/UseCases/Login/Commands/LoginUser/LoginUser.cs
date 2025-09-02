using Mukhametshin_Test_Aviakod.UseCases.Infrastructure.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Login.Commands.LoginUser;

public static class LoginUser
{
    public record Command(string UserName, string Password) : ICommand<string?>;
}