namespace BlogNet.Domain.Models;
public class EntityModel
{
    public EntityModel()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
