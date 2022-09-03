using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.ProgramingLanguages.Commands.Create;
using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetById;
using Application.Features.ProgramingLanguages.Queries.GetList;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageController : BaseController
    {
        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand command)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery query)
        {
            GetByIdProgramingLanguageDto result = await Mediator.Send(query);
            return Created("", result);
        }

        [HttpGet(nameof(GetList))]
        public async Task<IActionResult> GetList([FromQuery] PageRequest request)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() {PageRequest = request};
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Created("", result);
        }
    }
}