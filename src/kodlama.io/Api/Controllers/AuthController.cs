using Application.Features.Auth.Command.Register;
using Application.Features.Auth.Queries.Login;
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
public class AuthController : BaseController
{
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await Mediator!.Send(command);
        return Created("", result);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromQuery] LoginQuery query)
    {
        var result = await Mediator!.Send(query);
        return Ok(result);
    }
}