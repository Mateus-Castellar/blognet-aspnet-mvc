using BlogNet.Domain.Models;

namespace BlogNet.Domain.Interfaces;

public interface IPostRepository : IRepository<PostModel>
{
    Task<List<PostModel>> ObterPostsPorUsuarioId(Guid userId);
    Task CurtirPost(CurtidaModel curtida);
    Task DescurtirPost(CurtidaModel curtida);
    Task<PostModel?> ObterPostCurtidasPorId(Guid id);
}
