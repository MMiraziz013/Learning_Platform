using Clean.Application.Abstractions;
using Clean.Application.Security.Permission;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Platform.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("user/{id:int}")]
    [PermissionAuthorize(PermissionConstants.Users.View)]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var response = await _userService.GetUserByIdAsync(id);
        return StatusCode(response.StatusCode, response);
    }
}