using MediatR;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.DeleteIssue;

using static DeleteIssue;

public class DeleteIssueHandler : IRequestHandler<Command>
{
    private readonly IIssueRepository _issueRepository;

    public DeleteIssueHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        await _issueRepository.Delete(request.IssueId, request.UserId, cancellationToken);
    }
}