using MediatR;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Queries.GetIssue;

public static class GetIssue
{
    public record Query(Guid IssueId, Guid UserId) : IRequest<Response>;

    public record Response(IssueData? Data);
}