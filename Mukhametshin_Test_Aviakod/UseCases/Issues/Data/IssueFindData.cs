using Mukhametshin_Test_Aviakod.Domain.Entities.Constants;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Data;

public record IssueFindData(string? Search, IssueStatus? Status, int? Skip, int? Take);