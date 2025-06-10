using Microsoft.AspNetCore.Mvc;
using Tutdocs.Domain.Entities;
using Tutdocs.Service.Interface;

namespace TutdocsWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
        
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Users>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] Users user)
    {
        var result = await _userService.CreateUserAsync(user);
        if (!result) return BadRequest("Could not create user");
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, [FromBody] Users user)
    {
        if (id != user.Id)
            return BadRequest("User ID mismatch");

        var existingUser = await _userService.GetUserByIdAsync(id);
        if (existingUser == null) return NotFound();

        var result = await _userService.UpdateUserAsync(user);
        if (!result) return BadRequest("Could not update user");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var result = await _userService.DeleteUserAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}