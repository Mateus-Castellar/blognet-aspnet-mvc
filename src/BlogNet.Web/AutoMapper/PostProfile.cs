using AutoMapper;
using BlogNet.Domain.Models;
using BlogNet.Web.ViewModels;

namespace BlogNet.Web.AutoMapper;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<PostViewModel, PostModel>();

        CreateMap<PostModel, PostViewModel>()
            .ForMember(des => des.Curtidas, opt
            => opt.MapFrom(src => src.Curtidas.Count)
            ).ForMember(des => des.Comentarios, opt
            => opt.MapFrom(src => src.Comentarios.Count));
    }
}
