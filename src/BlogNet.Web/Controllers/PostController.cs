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
    private readonly IPostRepository _postRepository;

    public PostController(IPostService postService, IMapper mapper, UserManager<IdentityUser> user,
        IPostRepository postRepository)
    {
        _postService = postService;
        _mapper = mapper;
        _user = user;
        _postRepository = postRepository;
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
        postViewModel.CriadoEm = DateTime.Now;

        await _postService.Adicionar(_mapper.Map<PostModel>(postViewModel));

        return RedirectToAction("Index", "Home");
    }

    [Route("meus-posts")]
    public async Task<IActionResult> LIstarPostsPorUsuario()
    {
        var user = await _user.GetUserAsync(User);
        var posts = await _postRepository.ObterPostsPorUsuarioId(Guid.Parse(user!.Id));
        return View(_mapper.Map<List<PostViewModel>>(posts));
    }

    [Route("editar-post/{id}")]
    public async Task<IActionResult> Editar(Guid id)
    {
        var post = await _postRepository.ObterPorId(id);

        if (post is null) return NotFound();

        return View(_mapper.Map<PostViewModel>(post));
    }

    [HttpPost]
    [Route("editar-post/{id:guid}")]
    public async Task<IActionResult> Editar(Guid id, PostViewModel postViewModel)
    {
        if (id != postViewModel.Id) return NotFound();

        if (ModelState.IsValid is false) return View(postViewModel);


        var postAtualizado = await _postRepository.ObterPorId(id);

        if (postAtualizado is null) return NotFound();

        postAtualizado.Descricao = postViewModel.Descricao;
        postAtualizado.Titulo = postViewModel.Titulo;
        postAtualizado.Curtidas = postViewModel.Curtidas;
        postAtualizado.AtualizadoEm = DateTime.Now;

        await _postRepository.Atualizar(postAtualizado);

        return RedirectToAction("Index", "Home");
    }
}
