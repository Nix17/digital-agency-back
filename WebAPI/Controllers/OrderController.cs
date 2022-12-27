using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class OrderController: BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddNew()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> AddNew([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSelected()
    {
        return Ok();
    }
}
