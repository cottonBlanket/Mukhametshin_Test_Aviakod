using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.Mappers.Issue;

using Domain.Entities;

public static class IssueDataMapper
{
    public static IssueData ToData(this Issue domain)
    {
        return new IssueData(domain.Id, domain.Title, domain.Description, domain.Status, domain.Added, domain.Modified);
    }
}