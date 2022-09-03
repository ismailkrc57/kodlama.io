using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Queries.GetById;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgramingLanguages.Queries.QueryHandlers;

public class
    GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery,
        GetByIdProgramingLanguageDto>
{
    private readonly ProgramingLanguageBusinessRule _businessRule;
    private readonly IMapper _mapper;
    private readonly IProgramingLanguageRepo _programingLanguageRepo;

    public GetByIdProgramingLanguageQueryHandler(IProgramingLanguageRepo programingLanguageRepo, IMapper mapper,
        ProgramingLanguageBusinessRule businessRule)
    {
        _programingLanguageRepo = programingLanguageRepo;
        _mapper = mapper;
        _businessRule = businessRule;
    }

    public async Task<GetByIdProgramingLanguageDto> Handle(GetByIdProgramingLanguageQuery request,
        CancellationToken cancellationToken)
    {
        var programingLanguage = await _programingLanguageRepo.GetAsync(pl => pl.Id == request.Id);
        _businessRule.ProgramingLanguageShouldBeExistWhenRequested(programingLanguage);
        var getByIdPlDto = _mapper.Map<GetByIdProgramingLanguageDto>(programingLanguage);
        return getByIdPlDto;
    }
}