using Mukhametshin_Test_Aviakod.UseCases.Infrastructure.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.DeleteIssue;

public static class DeleteIssue
{
    public record Command(Guid IssueId, Guid UserId) : ICommand;
}