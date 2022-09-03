using Application.Features.ProgramingLanguages.Dto;
using MediatR;

namespace Application.Features.ProgramingLanguages.Queries.GetById;

public class GetByIdProgramingLanguageQuery : IRequest<GetByIdProgramingLanguageDto>
{
    public int Id { get; set; }
}