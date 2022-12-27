using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class AuthController: BaseApiController
{
    [HttpPost("reg")]
    public async Task<IActionResult> RegistrationUser()
    {
        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> PostToken()
    {
        return Ok();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> PostRefresh()
    {
        return Ok();
    }
}
