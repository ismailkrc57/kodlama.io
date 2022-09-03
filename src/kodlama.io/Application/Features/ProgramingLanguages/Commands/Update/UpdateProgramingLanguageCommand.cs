using Application.Features.ProgramingLanguages.Dto;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.Update;

public class UpdateProgramingLanguageCommand : IRequest<UpdatedProgramingLanguageDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}