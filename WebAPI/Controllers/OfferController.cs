using Application.DTO.Offer;
using Application.Features.Offer.Commands;
using Application.Features.Offer.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class OfferController: BaseApiController
{
    [HttpGet("number")]
    public async Task<IActionResult> GenerateOfferNumber()
    {
        return Ok(await Mediator.Send(new GetUniqueOfferNumberQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllOffersQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetSingleOfferQuery(id)));
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetAllByUserId([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetAllOffersByUserIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] OfferForm form)
    {
        return Ok(await Mediator.Send(new CreateOfferCommand(form)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] OfferForm form)
    {
        return Ok(await Mediator.Send(new UpdateOfferCommand(id, form)));
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSelected([FromBody] List<Guid> ids)
    {
        return Ok(await Mediator.Send(new DeleteOffersCommand(ids)));
    }
}
