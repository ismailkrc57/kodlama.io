using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Queries.GetById;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Queries.QueryHandlers;

public class
    GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery,
        GetByIdProgramingLanguageDto>
{
    private IProgramingLanguageRepo _programingLanguageRepo;
    private IMapper _mapper;
    private ProgramingLanguageBusinessRule _businessRule;

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
        ProgramingLanguage? programingLanguage = await _programingLanguageRepo.GetAsync(pl => pl.Id == request.Id);
        _businessRule.ProgramingLanguageShouldBeExistWhenRequested(programingLanguage);
        GetByIdProgramingLanguageDto getByIdPlDto = _mapper.Map<GetByIdProgramingLanguageDto>(programingLanguage);
        return getByIdPlDto;
    }
}