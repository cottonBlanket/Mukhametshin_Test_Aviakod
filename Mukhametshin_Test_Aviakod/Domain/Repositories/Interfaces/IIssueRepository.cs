using Mukhametshin_Test_Aviakod.Domain.Entities;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;

public interface IIssueRepository
{
    Task<IReadOnlyCollection<Issue>> Find(IssueFindData data, Guid userId, CancellationToken ct);
    
    Task<Issue?> Get(Guid id, Guid userId, CancellationToken ct);
    Task<Issue> Add(Issue entity, CancellationToken ct);
    Task<Issue> Update(Issue entity, CancellationToken ct);
    
    Task Delete(Guid issueId, Guid userId, CancellationToken ct);
}