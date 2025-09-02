using Mukhametshin_Test_Aviakod.Domain.Entities.Constants;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

public record IssueUpdateData(Guid Id, string? Title, string? Description, IssueStatus? Status);
