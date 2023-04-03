using AutoMapper;
using BlogNet.Domain.Interfaces;
using BlogNet.Domain.Models;
using BlogNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogNet.Web.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
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

        await _postService.Adicionar(_mapper.Map<PostModel>(postViewModel));

        return RedirectToAction("Index", "Home");
    }
}
