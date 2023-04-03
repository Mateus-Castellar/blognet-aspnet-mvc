using AutoMapper;
using BlogNet.Domain.Interfaces;
using BlogNet.Domain.Models;
using BlogNet.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogNet.Web.Controllers;

[Authorize]
public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _user;

    public PostController(IPostService postService, IMapper mapper, UserManager<IdentityUser> user)
    {
        _postService = postService;
        _mapper = mapper;
        _user = user;
    }

    [Route("novo-post")]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    [Route("novo-post")]
    public async Task<IActionResult> Cadastro(PostViewModel postViewModel)
    {
        if (ModelState.IsValid is false) return View(postViewModel);

        var user = await _user.GetUserAsync(User);
        postViewModel.UserId = Guid.Parse(user!.Id);

        await _postService.Adicionar(_mapper.Map<PostModel>(postViewModel));

        return RedirectToAction("Index", "Home");
    }
}
