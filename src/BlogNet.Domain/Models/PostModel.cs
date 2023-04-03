namespace BlogNet.Domain.Models;

public class PostModel : EntityModel
{
    public required string Imagem { get; set; }
    public required string Titulo { get; set; }
    public required string Descricao { get; set; }
    public int? Curtidas { get; set; }
    public required DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
    public Guid UserId { get; set; }
}
