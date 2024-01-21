namespace Framework.Domain;

public class EntityBase
{
    public long Id { get; protected set; }
    public DateTime CreationDate { get; protected set; }
}