using Mukhametshin_Test_Aviakod.UseCases.Infrastructure.Interfaces;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.CreateIssue;

public static class CreateIssue
{
    public record Command(IssueCreateData Data, Guid UserId) : ICommand<Guid>, IValidated;
}