using MediatR;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.UpdateIssue;

using static UpdateIssue;

public class UpdateIssueHandler : IRequestHandler<Command>
{
    private readonly IIssueRepository _issueRepository;

    public UpdateIssueHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task Handle(Command request, CancellationToken ct)
    {
        var (data, userId) = request;
        var issue = await _issueRepository.Get(data.Id, userId, ct);
        if (issue is null)
        {
            return;
        }

        if (string.IsNullOrEmpty(data.Title) == false)
        {
            issue.Title = data.Title;
        }

        if (string.IsNullOrEmpty(data.Description) == false)
        {
            issue.Description = data.Description;
        }

        if (data.Status.HasValue)
        {
            issue.Status = data.Status.Value;
        }
        
        issue.Modified = DateTime.Now;
        await _issueRepository.Update(issue, ct);
    }
}