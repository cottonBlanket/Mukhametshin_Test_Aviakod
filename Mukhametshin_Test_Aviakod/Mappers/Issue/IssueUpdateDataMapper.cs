using Mukhametshin_Test_Aviakod.Dto.Issue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.Mappers.Issue;

public static class IssueUpdateDataMapper
{
    public static IssueUpdateData ToData(this IssueUpdateDto dto)
    {
        return new IssueUpdateData(dto.Id, dto.Title, dto.Description, dto.Status);
    }
}