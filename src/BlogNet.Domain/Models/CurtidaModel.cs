namespace BlogNet.Domain.Models;
public class CurtidaModel : EntityModel
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
    public DateTime CriadoEm { get; set; }

    //EfCore Relational
    public PostModel? PostModel { get; set; }
}
