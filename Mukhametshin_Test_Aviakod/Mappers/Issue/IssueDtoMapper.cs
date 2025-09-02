using Mukhametshin_Test_Aviakod.Dto.Issue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.Mappers.Issue;

public static class IssueDtoMapper
{
    public static IssueDto ToDto(this IssueData data)
    {
        return new IssueDto
        {
            Id = data.Id,
            Title = data.Title,
            Description = data.Description,
            Status = data.Status,
            Added = data.Added,
            Modified = data.Modified,
        };
    }
}