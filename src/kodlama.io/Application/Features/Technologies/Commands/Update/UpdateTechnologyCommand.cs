using Application.Features.Technologies.Dto;
using MediatR;

namespace Application.Features.Technologies.Commands.Update;

public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
{
    public int TechnologyId { get; set; }
    public string Name { get; set; }
    public int ProgramingLanguageId { get; set; }
}