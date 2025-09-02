using MediatR;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;
using Mukhametshin_Test_Aviakod.Mappers.Issue;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Queries.FindIssues;

using static FindIssues;

public class FindIssuesHandler : IRequestHandler<Query, Response>
{
    private readonly IIssueRepository _issueRepository;

    public FindIssuesHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<Response> Handle(Query request, CancellationToken ct)
    {
        var (data, userId) = request;
        var issues = await _issueRepository.Find(data, userId, ct);
        return new Response(issues.Select(i => i.ToData()).ToList());
    }
}