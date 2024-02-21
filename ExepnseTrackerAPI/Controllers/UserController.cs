using ExepnseTrackerAPI.Services;
using ExepnseTrackerAPI.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ExepnseTrackerAPI.Class;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class UserController  : ControllerBase
{
    private readonly ClsUser _clsUser;

    public UserController(ClsUser clsUser)
    {
        _clsUser = clsUser;
    }

    //[HttpPost("AddUser")]
    //public async Task<IActionResult> AddUser([FromBody] TblUser user)
    //{
    //    try
    //    {
    //        var result = await _clsUser.AddUserAsync(user);
    //        return Ok(result); 
    //    }
    //    catch (ArgumentNullException)
    //    {
    //        return BadRequest("User data is required");
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, $"Internal server error: {ex.Message}");
    //    }
    //}

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

    [HttpPost("AddUser")]
    public ErrorResult Adduser(UserCredentials user)
    {
        ErrorResult result = new ErrorResult();
        try
        {
            if (String.IsNullOrEmpty(user.username) && String.IsNullOrEmpty(user.password))
            {
                throw new ArgumentNullException();
            }
            else
            {
                var res = _clsUser.AddUser(user.username, user.password);
                if (res.errormessage != null)
                {
                    result.errormessage= res.errormessage;
                }
                if(res.warningmessage != null)
                {
                    result.warningmessage= res.warningmessage;
                }
                else
                {
                    result.success = res.success; 
                }
            }
        }
        catch (ArgumentNullException ex)
        {
            Log.Error(ex.Message);
            result.errormessage += ex.Message;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            result.errormessage += ex.Message; 
        }
        return result;
    }
}

public class UserCredentials
{
    public string username { get; set; }
    public string password { get; set; }
}





