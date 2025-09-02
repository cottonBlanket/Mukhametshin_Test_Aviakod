namespace Mukhametshin_Test_Aviakod.Domain.Entities.Base;

public class BaseEntity: IEntityGuidPk, IEntityAdded, IEntityModified
{
    public Guid Id { get; init; }
    public DateTime Added { get; set; }
    public DateTime Modified { get; set; }
    
    public Guid AddedBy { get; init; }
}