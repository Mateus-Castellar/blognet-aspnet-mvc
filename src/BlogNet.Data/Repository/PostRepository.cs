using BlogNet.Data.Context;
using BlogNet.Domain.Interfaces;
using BlogNet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNet.Data.Repository;
public class PostRepository : Repository<PostModel>, IPostRepository
{
    public PostRepository(AppBlogContext context) : base(context) { }

    public async Task<List<PostModel>> ObterPostsPorUsuarioId(Guid userId)
    {
        return await _dbSet
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}
