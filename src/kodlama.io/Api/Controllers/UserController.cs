using Application.Features.Users.Command.Delete;
using Application.Features.Users.Command.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    [HttpGet(nameof(GetList))]
    public async Task<IActionResult> GetList([FromQuery] PageRequest request)
    {
        UserGetListQuery userGetListQuery = new() { PageRequest = request };
        var result = await Mediator!.Send(userGetListQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{Id}")]
    public async Task<IActionResult> GetById([FromRoute] UserGetByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpPut(nameof(UpdatePut))]
    public async Task<IActionResult> UpdatePut([FromBody] UpdateUserCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPatch(nameof(UpdatePatch))]
    public async Task<IActionResult> UpdatePatch([FromBody] UpdateUserCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }
}