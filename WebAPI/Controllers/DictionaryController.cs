using Application.DTO.Dictionary;
using Application.Features.Dictionary.Commands;
using Application.Features.Dictionary.Queries;
using Domain.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers;

public class DictionaryController : BaseApiController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllById([FromRoute] int id)
    {
        var dictId = (DictionaryIdentificator)id;
        return Ok(await Mediator.Send(new GetAllDictByDictIdQuery(dictId)));
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddNew([FromRoute] int id, [FromBody] DictionaryForm form)
    {
        var dictId = (DictionaryIdentificator)id;
        return Ok(await Mediator.Send(new CreateDictCommand(dictId, form)));
    }

    [HttpPut("{dictId}/record/{id}")]
    public async Task<IActionResult> Update([FromRoute] int dictId, int id, [FromBody] DictionaryForm form)
    {
        var _dictId = (DictionaryIdentificator)dictId;
        return Ok(await Mediator.Send(new UpdateDictCommand(_dictId, id, form)));
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSelected([FromBody] DictionaryArrayIntIdsForm form)
    {
        return Ok(await Mediator.Send(new DeleteSelectedDictCommand(form.DictIdentificators, form.Ids)));
    }
}
