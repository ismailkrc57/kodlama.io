using Application.Features.GithubAccounts.Commands.Create;
using Application.Features.GithubAccounts.Commands.Delete;
using Application.Features.GithubAccounts.Commands.Update;
using Application.Features.GithubAccounts.Queries.GetById;
using Application.Features.GithubAccounts.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GithubAccountController : BaseController
{
    [HttpPost(nameof(Add))]
    public async Task<IActionResult> Add([FromBody] CreateAccountCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpGet(nameof(GetList))]
    public async Task<IActionResult> GetList([FromQuery] PageRequest request)
    {
        AccountListQuery query = new() { PageRequest = request };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet("GetById/{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdAccountQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }


    [HttpDelete("Delete/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteAccountCommand command)
    {
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpPut(nameof(UpdatePut))]
    public async Task<IActionResult> UpdatePut([FromBody] UpdateAccountCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPatch(nameof(UpdatePatch))]
    public async Task<IActionResult> UpdatePatch([FromBody] UpdateAccountCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }
}