using ExepnseTrackerAPI.Services;
using ExepnseTrackerAPI.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ClsUser _clsUser;

    public UserController(ClsUser clsUser)
    {
        _clsUser = clsUser;
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser([FromBody] TblUser user)
    {
        try
        {
            var result = await _clsUser.AddUserAsync(user);
            return Ok(result); 
        }
        catch (ArgumentNullException)
        {
            return BadRequest("User data is required");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("GetUser")]
    public async Task<ActionResult<IEnumerable<TblUser>>> GetUsers()
    {
        var users = await _clsUser.GetUsersAsync();
        return Ok(users);
    }
}
