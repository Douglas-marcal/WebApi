using WebApi.DTOs;
using WebApi.Models;
using WebApi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers.Request;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    public UserController(IUnitOfWork context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("Posts")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserPosts()
    {
        var users = await _context.UserRepository.GetUsersPosts();

        var usersDto = _mapper.Map<List<UserDTO>>(users);

        return usersDto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
    {
        var users = await _context.UserRepository.Get().ToListAsync();

        var usersDto = _mapper.Map<List<UserDTO>>(users);

        return usersDto;
    }

    [HttpGet("{id}", Name = "ObterCategoria")]
    public async Task<ActionResult<UserDTO>> Get(int id)
    {
        var user = await _context.UserRepository.GetByCondition(p => p.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDTO>(user);

        return userDto;
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterRequest userRequest)
    {
        var userExists = await _context.UserRepository.CheckIfUserExistsByEmail(userRequest.Email!);

        if (userExists is not null)
            return BadRequest("User already Exists.");

        var user = UserService.UserInstance(userRequest);

        _context.UserRepository.Add(user);
        await _context.Commit();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UserDTO userDto)
    {
        if (id != userDto.Id)
            return BadRequest();

        var user = _mapper.Map<User>(userDto);

        _context.UserRepository.Update(user);
        await _context.Commit();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDTO>> Delete(int id)
    {
        var user = await _context.UserRepository.GetByCondition(p => p.Id == id);

        if (user is null)
            return NotFound();

        _context.UserRepository.Delete(user);
        await _context.Commit();

        var userDto = _mapper.Map<UserDTO>(user);

        return userDto;
    }
}
