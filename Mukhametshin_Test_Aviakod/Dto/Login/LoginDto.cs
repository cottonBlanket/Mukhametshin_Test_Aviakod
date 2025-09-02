using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mukhametshin_Test_Aviakod.Dto.Login;

public class LoginDto
{
    [Required]
    [JsonPropertyName("username")]
    public required string Username { get; init; }
    
    [Required]
    [JsonPropertyName("password")]
    public required string Password { get; init; }
}