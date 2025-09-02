using Mukhametshin_Test_Aviakod.UseCases.Infrastructure.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Login.Commands.RegisterUser;

public static class RegisterUser
{
    public record Command(string UserName, string Password) : ICommand<Guid>;
}