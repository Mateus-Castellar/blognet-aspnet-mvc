using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogNet.Web.ViewModels;

public class PostViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    public required string Imagem { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    public required string Titulo { get; set; }

    [DisplayName("Descricao")]
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    public required string Descricao { get; set; }

    [DisplayName("Data de Criação")]
    public required DateTime CriadoEm { get; set; }

    [DisplayName("Atualizado Em")]
    public DateTime? AtualizadoEm { get; set; }

    public Guid UserId { get; set; }

    public int? Curtidas { get; set; }
}
