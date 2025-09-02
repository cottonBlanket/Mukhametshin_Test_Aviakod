using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Mukhametshin_Test_Aviakod.Domain.Entities.Constants;

namespace Mukhametshin_Test_Aviakod.Dto.Issue;

public class IssueUpdateDto
{
    [Required]
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
    
    [JsonPropertyName("title")]
    public string? Title { get; init; }
    
    [JsonPropertyName("description")]
    public string? Description { get; init; }
    
    [JsonPropertyName("status")]
    public IssueStatus? Status { get; init; }
}