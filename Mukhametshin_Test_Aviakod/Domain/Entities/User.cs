using Mukhametshin_Test_Aviakod.Domain.Entities.Base;

namespace Mukhametshin_Test_Aviakod.Domain.Entities;

public class User : IEntityGuidPk, IEntityAdded
{
    public Guid Id { get; init; }
    public required string Username { get; set; } 
    public required string PasswordHash { get; set; } 
    public DateTime Added { get; set; }
}
