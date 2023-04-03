using BlogNet.Domain.Interfaces;
using BlogNet.Domain.Models;

namespace BlogNet.Domain.Services;
public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task Adicionar(PostModel post)
    {
        //todo: validações

        await _postRepository.Adicionar(post);
    }
}
