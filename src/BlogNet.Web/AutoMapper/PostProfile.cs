using AutoMapper;
using BlogNet.Domain.Models;
using BlogNet.Web.ViewModels;

namespace BlogNet.Web.AutoMapper;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<PostViewModel, PostModel>();
    }
}
