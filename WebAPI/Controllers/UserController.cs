using Application.DTO.Dictionary;
using Application.DTO.User;
using Application.Features.Dictionary.Commands;
using Application.Features.Dictionary.Queries;
using Application.Features.User.Commands;
using Application.Features.User.Queries;
using Domain.Data;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class UserController: BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllUsersQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetUserByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] UserRegForm form)
    {
        return Ok(await Mediator.Send(new CreateUserCommand(form)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserUpdateForm form)
    {
        return Ok(await Mediator.Send(new UpdateUserCommand(id, form)));
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSelected(List<Guid> ids)
    {
        return Ok(await Mediator.Send(new DeleteUserCommand(ids)));
    }
}
