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
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _user;
    private readonly IPostRepository _postRepository;

    public PostController(IMapper mapper, UserManager<IdentityUser> user,
        IPostRepository postRepository)
    {
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

        await _postRepository.Adicionar(_mapper.Map<PostModel>(postViewModel));

        return RedirectToAction("Index", "Home");
    }

    [Route("meus-posts")]
    public async Task<IActionResult> ListarPostsPorUsuario()
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
        postAtualizado.AtualizadoEm = DateTime.Now;

        await _postRepository.Atualizar(postAtualizado);

        return RedirectToAction("Index", "Home");
    }

    [Route("remover-post/{id:guid}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        var post = await _postRepository.ObterPorId(id);

        if (post is null) return NotFound();

        return View("Deletar", _mapper.Map<PostViewModel>(post));
    }

    [Route("remover-post/{id:guid}")]
    [HttpPost, ActionName("Remover")]
    public async Task<IActionResult> RemoverConfirmacao(Guid id)
    {
        var post = await _postRepository.ObterPorId(id);

        if (post is null) return NotFound();

        await _postRepository.Remover(post.Id);

        return RedirectToAction(nameof(ListarPostsPorUsuario));
    }

    [HttpPost("curtir")]
    public async Task<IActionResult> CurtirPost(Guid id)
    {
        var post = await _postRepository.ObterPostCurtidasPorId(id);

        if (post is null) return NotFound();

        var user = await _user.GetUserAsync(User);

        var jaCurtiu = post.Curtidas?
            .FirstOrDefault(x => x.UserId == Guid.Parse(user!.Id));

        //se já curtiu ele deve descurtir
        if (jaCurtiu is not null)
        {
            await _postRepository.DescurtirPost(jaCurtiu);
            return RedirectToAction(nameof(ListarPostsPorUsuario));
        }

        var curtida = new CurtidaModel()
        {
            PostId = post.Id,
            CriadoEm = DateTime.Now,
            UserId = Guid.Parse(user!.Id),
        };

        await _postRepository.CurtirPost(curtida);

        return RedirectToAction(nameof(ListarPostsPorUsuario));
    }

    [HttpPost("comentar")]
    public async Task<IActionResult> ComentarPost(Guid id, string comentario)
    {
        var post = await _postRepository.ObterPorId(id);

        if (post is null) return NotFound();

        var user = await _user.GetUserAsync(User);

        var novoComentario = new ComentarioModel()
        {
            CriadoEm = DateTime.Now,
            PostId = post.Id,
            Texto = comentario,
            UserId = Guid.Parse(user!.Id),
        };

        await _postRepository.AdicionarComentario(novoComentario);

        return RedirectToAction(nameof(ListarPostsPorUsuario));
    }
}
