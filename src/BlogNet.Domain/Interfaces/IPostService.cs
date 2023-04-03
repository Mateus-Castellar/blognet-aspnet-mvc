using BlogNet.Domain.Models;

namespace BlogNet.Domain.Interfaces;
public interface IPostService
{
    Task Adicionar(PostModel post);
}
