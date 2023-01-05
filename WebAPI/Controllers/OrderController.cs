using Application.DTO.Order;
using Application.Features.Offer.Queries;
using Application.Features.Order.Commands;
using Application.Features.Order.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class OrderController: BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllOrdersQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] OrderForm form)
    {
        return Ok(await Mediator.Send(new CreateOrderCommand(form)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetSingleOrderQuery(id)));
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetAllByUserId([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetAllOrdersByUserIdQuery(id)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] OrderForm form)
    {
        return Ok(await Mediator.Send(new UpdateOrderCommand(id, form)));
    }

    [HttpPut("{id}/order-cost")]
    public async Task<IActionResult> UpdateOrderCost([FromRoute] Guid id, [FromBody] OrderFormUpd form)
    {
        return Ok(await Mediator.Send(new UpdateOrderCostCommand(id, form)));
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSelected([FromBody] List<Guid> ids)
    {
        return Ok(await Mediator.Send(new DeleteOrdersCommand(ids)));
    }

}
