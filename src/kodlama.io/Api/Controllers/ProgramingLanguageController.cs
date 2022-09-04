using Application.Features.ProgramingLanguages.Commands.Create;
using Application.Features.ProgramingLanguages.Commands.Delete;
using Application.Features.ProgramingLanguages.Commands.Update;
using Application.Features.ProgramingLanguages.Queries.GetById;
using Application.Features.ProgramingLanguages.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramingLanguageController : BaseController
{
    [HttpPost(nameof(Add))]
    public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpGet("GetById/{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
        
    }

    [HttpGet(nameof(GetList))]
    public async Task<IActionResult> GetList([FromQuery] PageRequest request)
    {
        GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() {PageRequest = request};
        var result = await Mediator!.Send(getListProgramingLanguageQuery);
        return Ok( result);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteProgramingLanguageCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpPut(nameof(UpdatePut))]
    public async Task<IActionResult> UpdatePut([FromBody] UpdateProgramingLanguageCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPatch(nameof(UpdatePatch))]
    public async Task<IActionResult> UpdatePatch([FromBody] UpdateProgramingLanguageCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }
}