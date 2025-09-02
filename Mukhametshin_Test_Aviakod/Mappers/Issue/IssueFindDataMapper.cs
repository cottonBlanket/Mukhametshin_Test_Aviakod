using Mukhametshin_Test_Aviakod.Dto.Issue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

namespace Mukhametshin_Test_Aviakod.Mappers.Issue;

public static class IssueFindDataMapper
{
    public static IssueFindData ToData(this IssueFindDto dto)
    {
        return new IssueFindData(dto.Search, dto.Status, dto.Skip, dto.Take);
    }
}