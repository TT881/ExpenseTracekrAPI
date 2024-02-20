using ExepnseTrackerAPI.Services;
using ExepnseTrackerAPI.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController  : ControllerBase
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

    [HttpPost("ValidateUser")]
    public async Task<ActionResult> ValidateUser(UserCredentials user)
    {
        try
        {
            if(String.IsNullOrEmpty(user.username) && String.IsNullOrEmpty(user.password))
            {
                throw new ArgumentNullException();
            }
            else
            {
                var result =  _clsUser.ValidateUser(user.username, user.password);
                return Ok(result);
            }
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
}

public class UserCredentials
{
    public string username { get; set; }
    public string password { get; set; }
}



