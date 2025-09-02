using Mukhametshin_Test_Aviakod.Domain.Entities.Constants;
using Mukhametshin_Test_Aviakod.Dto.Common;

namespace Mukhametshin_Test_Aviakod.Dto.Issue;

public class IssueFindDto : FindDto
{
    public string? Search { get; init; }
    
    public IssueStatus? Status { get; init; }
}