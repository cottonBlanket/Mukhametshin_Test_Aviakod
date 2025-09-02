using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mukhametshin_Test_Aviakod.Dto.Issue;

public class IssueCreateDto
{
    [Required]
    [JsonPropertyName("title")]
    [MaxLength(255)]
    public required string Title { get; set; }
    
    [JsonPropertyName("description")]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;
}