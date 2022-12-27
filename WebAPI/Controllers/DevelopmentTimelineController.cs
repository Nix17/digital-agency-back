using Application.DTO.DevelopmentTimeline;
using Application.Features.DevelopmentTimeline.Commands;
using Application.Features.DevelopmentTimeline.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class DevelopmentTimelineController: BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllDevelopmentTimelineQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] DevelopmentTimelineForm form)
    {
        return Ok(await Mediator.Send(new CreateDevelopmentTimelineCommand(form)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DevelopmentTimelineForm form)
    {
        return Ok(await Mediator.Send(new UpdateDevelopmentTimelineCommand(id, form)));
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSelected([FromBody] List<int> ids)
    {
        return Ok(await Mediator.Send(new DeleteDevelopmentTimelineCommand(ids)));
    }
}
