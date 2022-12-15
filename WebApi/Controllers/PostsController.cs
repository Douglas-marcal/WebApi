using WebApi.DTOs;
using WebApi.Models;
using WebApi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public PostsController(IUnitOfWork context, IMapper mapper)
    {
        _uof = context;
        _mapper = mapper;
    }

    [HttpGet("NewestPosts")]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetNewestPosts()
    {
        var posts = await _uof.PostRepository.GetByNewestPosts();
        var postsDto = _mapper.Map<List<PostDTO>>(posts);

        return postsDto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostDTO>>> Get()
    {
        var posts = await _uof.PostRepository.Get().ToListAsync();
        var postsDto = _mapper.Map<List<PostDTO>>(posts);

        return postsDto;
    }

    [HttpGet("{id}", Name = "GetPost")]
    public async Task<ActionResult<PostDTO>> Get(int id)
    {
        var post = await _uof.PostRepository.GetByCondition(p => p.Id == id);

        if (post is null)
            return NotFound();

        var postDto = _mapper.Map<PostDTO>(post);

        return postDto;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostDTO postDto)
    {
        var post = _mapper.Map<Post>(postDto);

        _uof.PostRepository.Add(post);
        await _uof.Commit();

        var postDTO = _mapper.Map<PostDTO>(post);

        return new CreatedAtRouteResult("GetPost", new { id = post.Id }, postDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] PostDTO postDto)
    {
        if (id != postDto.Id)
            return BadRequest();

        var post = _mapper.Map<Post>(postDto);

        _uof.PostRepository.Update(post);
        await _uof.Commit();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PostDTO>> Delete(int id)
    {
        var post = await _uof.PostRepository.GetByCondition(p => p.Id == id);

        if (post is null)
            return NotFound();

        _uof.PostRepository.Delete(post);
        await _uof.Commit();

        var postDto = _mapper.Map<PostDTO>(post);

        return postDto;
    }
}
