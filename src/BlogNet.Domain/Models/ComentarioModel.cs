namespace BlogNet.Domain.Models;
public class ComentarioModel : EntityModel
{
    public required string Texto { get; set; }
    public required Guid UserId { get; set; }
    public required Guid PostId { get; set; }
    public required DateTime CriadoEm { get; set; }

    //EfCore Relational
    public PostModel Post { get; set; }
}
