using MediatR;
using Mukhametshin_Test_Aviakod.Domain.Entities;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.CreateIssue;

using static CreateIssue;

public class CreateIssueHandler : IRequestHandler<Command, Guid>
{
    private readonly IIssueRepository _issueRepository;

    public CreateIssueHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<Guid> Handle(Command request, CancellationToken ct)
    {
        var (data, userId) = request;

        var issue = new Issue
        {
            Title = data.Title,
            Description = data.Description,
            AddedBy = userId
        };

        await _issueRepository.Add(issue, ct);
        return issue.Id;
    }
}