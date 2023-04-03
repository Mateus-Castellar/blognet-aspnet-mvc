using BlogNet.Data.Context;
using BlogNet.Domain.Interfaces;
using BlogNet.Domain.Models;

namespace BlogNet.Data.Repository;
public class PostRepository : Repository<PostModel>, IPostRepository
{
    public PostRepository(AppBlogContext context) : base(context)
    {
    }
}
