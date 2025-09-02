using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Mukhametshin_Test_Aviakod.Domain.Entities.Constants;

namespace Mukhametshin_Test_Aviakod.Dto.Issue;

public class IssueDto
{
    [Required]
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
    
    [Required]
    [JsonPropertyName("title")]
    public required string Title { get; init; }
    
    [Required]
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    
    [Required]
    [JsonPropertyName("status")]
    public required IssueStatus Status { get; init; }
    
    [Required]
    [JsonPropertyName("added")]
    public required DateTime Added { get; init; }
    
    [Required]
    [JsonPropertyName("modified")]
    public required DateTime Modified { get; init; }
}