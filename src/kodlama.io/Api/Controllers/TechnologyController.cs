using Application.Features.Technologies.Commands.Create;
using Application.Features.Technologies.Commands.Delete;
using Application.Features.Technologies.Commands.Update;
using Application.Features.Technologies.Queries.GetById;
using Application.Features.Technologies.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechnologyController : BaseController
{
    [HttpPost(nameof(Add))]
    public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpGet(nameof(GetList))]
    public async Task<IActionResult> GetList([FromQuery] PageRequest request)
    {
        TechnologyListQuery technologyListQuery = new() { PageRequest = request };
        var result = await Mediator!.Send(technologyListQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }


    [HttpDelete("Delete/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpPut(nameof(UpdatePut))]
    public async Task<IActionResult> UpdatePut([FromBody] UpdateTechnologyCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPatch(nameof(UpdatePatch))]
    public async Task<IActionResult> UpdatePatch([FromBody] UpdateTechnologyCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }
}