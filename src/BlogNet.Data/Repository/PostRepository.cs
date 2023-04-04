using BlogNet.Data.Context;
using BlogNet.Domain.Interfaces;
using BlogNet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNet.Data.Repository;
public class PostRepository : Repository<PostModel>, IPostRepository
{
    public PostRepository(AppBlogContext context) : base(context) { }

    public async Task CurtirPost(CurtidaModel curtida)
    {
        _context.Curtidas.Add(curtida);
        await _context.SaveChangesAsync();
    }

    public async Task DescurtirPost(CurtidaModel curtida)
    {

        _context.Curtidas.Remove(curtida);
        await _context.SaveChangesAsync();
    }

    public async Task<PostModel?> ObterPostCurtidasPorId(Guid id)
    {
        return await _dbSet
            .Include(x => x.Curtidas)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PostModel>> ObterPostsPorUsuarioId(Guid userId)
    {
        return await _dbSet
            .Include(x => x.Curtidas)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}
