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

    [HttpPost("agreement")]
    public async Task<IActionResult> GetAllByAgreement([FromBody] bool agree)
    {
        return Ok(await Mediator.Send(new GetAllOrdersByAgreementQuery(agree)));
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

    [HttpGet("export-word")]
    public async Task<IActionResult> ExportToWord()
    {
        var docWord = await Mediator.Send(new ExportDataToWordQuery());

        return File(
                fileContents: docWord,
                contentType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileDownloadName: "OrdersFile.docx"
            );
    }

    [HttpGet("{userId}/export-word")]
    public async Task<IActionResult> ExportToWordByUserId([FromRoute] Guid userId)
    {
        var docWord = await Mediator.Send(new ExportDataToWordUserIdQuery(userId));

        return File(
                fileContents: docWord,
                contentType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileDownloadName: "OrdersFile.docx"
            );
    }

    [HttpPost("export-word/date")]
    public async Task<IActionResult> exportDataToWordByDate([FromBody] OrderListIdAgreementForm form)
    {
        var docWord = await Mediator.Send(new ExportDataToWordByDateQuery(form.Ids, form.Agreement));

        return File(
                fileContents: docWord,
                contentType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileDownloadName: "OrdersFile.docx"
            );
    }

}
