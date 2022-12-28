using Application.DTO.User;
using Application.Features.Auth.Commands;
using Application.Features.Auth.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;
public class AuthController: BaseApiController
{
    [HttpPost("reg")]

    [AllowAnonymous]
    public async Task<IActionResult> RegistrationUser([FromBody] UserRegForm form)
    {
        return Ok(await Mediator.Send(new RegistrationCommand(form)));
    }

    [HttpGet("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        return Ok(await Mediator.Send(new LogoutQuery()));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] UserAuthForm form)
    {
        return Ok(await Mediator.Send(new LoginCommand(form)));
    }
}
