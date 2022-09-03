using Application.Features.ProgramingLanguages.Dto;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.Create;

public class CreateProgramingLanguageCommand : IRequest<CreatedProgramingLanguageDto>
{
    public string Name { get; set; }
}