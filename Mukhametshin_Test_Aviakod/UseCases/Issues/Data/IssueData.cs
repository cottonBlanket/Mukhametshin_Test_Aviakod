using Mukhametshin_Test_Aviakod.Domain.Entities.Constants;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

public record IssueData(
    Guid Id,
    string Title,
    string Description,
    IssueStatus Status,
    DateTime Added,
    DateTime Modified
);