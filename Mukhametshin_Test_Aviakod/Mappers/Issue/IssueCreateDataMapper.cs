using Mukhametshin_Test_Aviakod.Dto.Issue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.Mappers.Issue;

public static class IssueCreateDataMapper
{
    public static IssueCreateData ToData(this IssueCreateDto dto)
    {
        return new IssueCreateData(dto.Title, dto.Description);
    }
}