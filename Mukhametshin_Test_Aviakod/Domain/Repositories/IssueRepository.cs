using Microsoft.EntityFrameworkCore;
using Mukhametshin_Test_Aviakod.DataAccess;
using Mukhametshin_Test_Aviakod.Domain.Entities;
using Mukhametshin_Test_Aviakod.Domain.Helpers;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.Domain.Repositories;

public class IssueRepository : IIssueRepository
{
    private readonly DataContext _db;

    public IssueRepository(DataContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<Issue>> Find(IssueFindData data, Guid userId, CancellationToken ct)
    {
        var issues = _db
            .Issues.AsNoTracking()
            .Where(i => i.AddedBy == userId);
        
        if (string.IsNullOrEmpty(data.Search) == false)
        {
            issues = issues.Where(i =>
                EF.Functions.ILike(
                    EF.Functions.Collate(i.Title, Db.CollationName),
                    Db.ContainsPattern(data.Search)
                ) ||
                EF.Functions.ILike(
                    EF.Functions.Collate(i.Description, Db.CollationName),
                    Db.ContainsPattern(data.Search)
                )
            );
        }

        if (data.Status.HasValue)
        {
            issues = issues.Where(i => i.Status == data.Status.Value);
        }

        issues = issues.UseLimiter(data.Skip, data.Take);

        return await issues.OrderByDescending(t => t.Added).ToListAsync(ct);
    }

    public Task<Issue?> Get(Guid id, Guid userId, CancellationToken ct)
    {
        return _db.Issues.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id && t.AddedBy == userId, ct);
    }

    public async Task<Issue> Add(Issue entity, CancellationToken ct)
    {
        _db.Issues.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }


    public async Task<Issue> Update(Issue entity, CancellationToken ct)
    {
        _db.Issues.Update(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }


    public async Task Delete(Guid issueId, Guid userId, CancellationToken ct)
    {
        await _db.Issues.Where(i => i.Id == issueId && i.AddedBy == userId).ExecuteDeleteAsync(ct);
    }
}