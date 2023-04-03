using BlogNet.Domain.Interfaces;
using BlogNet.Domain.Models;
using BlogNet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogNet.Web.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
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

        var novoPost = new PostModel()
        {
            Descricao = postViewModel.Descricao,
            Titulo = postViewModel.Titulo,
            Imagem = postViewModel.Imagem,
        };

        await _postService.Adicionar(novoPost);

        return RedirectToAction("Index", "Home");
    }
}
