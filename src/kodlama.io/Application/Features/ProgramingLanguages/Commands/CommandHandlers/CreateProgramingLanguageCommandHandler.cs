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
    private readonly ProgramingLanguageBusinessRule _businessRule;
    private readonly IMapper _mapper;
    private readonly IProgramingLanguageRepo _programingLanguageRepo;

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
        var mappedPl = _mapper.Map<ProgramingLanguage>(request);
        var createdPl = await _programingLanguageRepo.AddAsync(mappedPl);
        var createdPlDto = _mapper.Map<CreatedProgramingLanguageDto>(createdPl);
        return createdPlDto;
    }
}