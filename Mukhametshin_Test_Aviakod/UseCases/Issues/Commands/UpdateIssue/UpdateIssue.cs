using Mukhametshin_Test_Aviakod.UseCases.Infrastructure.Interfaces;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.UpdateIssue;

public static class UpdateIssue
{
    public record Command(IssueUpdateData Data, Guid UserId) : ICommand;
}