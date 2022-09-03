using Application.Features.ProgramingLanguages.Dto;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.Delete;

public class DeleteProgramingLanguageCommand : IRequest<DeletedProgramingLanguageDto>
{
    public int Id { get; set; }
}