using System.ComponentModel.DataAnnotations;
using Mukhametshin_Test_Aviakod.Domain.Entities.Base;
using Mukhametshin_Test_Aviakod.Domain.Entities.Constants;

namespace Mukhametshin_Test_Aviakod.Domain.Entities;

public class Issue : BaseEntity
{
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;
    
    public IssueStatus Status { get; set; } = IssueStatus.New;
}