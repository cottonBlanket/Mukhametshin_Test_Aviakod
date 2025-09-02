using MediatR;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Queries.FindIssues;

public static class FindIssues
{
    public record Query(IssueFindData Data, Guid UserId) : IRequest<Response>;
    
    public record Response(IReadOnlyCollection<IssueData> Issues);
}