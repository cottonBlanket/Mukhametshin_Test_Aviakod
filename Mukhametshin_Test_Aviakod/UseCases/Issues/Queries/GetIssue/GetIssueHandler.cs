using MediatR;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;
using Mukhametshin_Test_Aviakod.Mappers.Issue;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Queries.GetIssue;

using static GetIssue;

public class GetIssueHandler : IRequestHandler<Query, Response>
{
    private readonly IIssueRepository _issueRepository;

    public GetIssueHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<Response> Handle(Query request, CancellationToken ct)
    {
        var issue = await _issueRepository.Get(request.IssueId, request.UserId, ct);
        return new Response(issue?.ToData());
    }
}