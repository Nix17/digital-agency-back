using Application.Features.Graphs.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class GraphController: BaseApiController
{
    [HttpGet("{year}")]
    public async Task<IActionResult> GetGraphData([FromRoute] int year)
    {
        return Ok(await Mediator.Send(new GetGraphDataCountOffersOrdersQuery(year)));
    }
}
