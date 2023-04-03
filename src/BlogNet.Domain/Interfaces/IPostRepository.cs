using BlogNet.Domain.Models;

namespace BlogNet.Domain.Interfaces;

public interface IPostRepository : IRepository<PostModel>
{
    Task<List<PostModel>> ObterPostsPorUsuarioId(Guid userId);
}
