using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

public class OrderController: BaseApiController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddNew()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update()
    {
        return Ok();
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSelected()
    {
        return Ok();
    }
}
