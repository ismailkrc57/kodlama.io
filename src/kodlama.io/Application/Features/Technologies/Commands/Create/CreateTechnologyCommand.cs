using Application.Features.Technologies.Dto;
using MediatR;

namespace Application.Features.Technologies.Commands.Create;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
{
    public string Name { get; set; }
    public int ProgramingLanguageId { get; set; }
}