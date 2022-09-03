using Application.Features.ProgramingLanguages.Commands.Create;
using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.CommandHandlers;

public class
    CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand,
        CreatedProgramingLanguageDto>
{
    private readonly IProgramingLanguageRepo _programingLanguageRepo;
    private readonly ProgramingLanguageBusinessRule _businessRule;
    private readonly IMapper _mapper;

    public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepo programingLanguageRepo,
        ProgramingLanguageBusinessRule businessRule, IMapper mapper)
    {
        _programingLanguageRepo = programingLanguageRepo;
        _businessRule = businessRule;
        _mapper = mapper;
    }

  
    public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request,
        CancellationToken cancellationToken)
    {
        await _businessRule.ProgramingLanguageCanNotBeDuplicatedWhenInserted(request.Name);
        ProgramingLanguage mappedPl = _mapper.Map<ProgramingLanguage>(request);
        ProgramingLanguage createdPl = await _programingLanguageRepo.AddAsync(mappedPl);
        CreatedProgramingLanguageDto createdPlDto = _mapper.Map<CreatedProgramingLanguageDto>(createdPl);
        return createdPlDto;
    }
}