using Application.Features.ProgramingLanguages.Commands.Update;
using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.CommandHandlers;

public class
    UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand,
        UpdatedProgramingLanguageDto>
{
    private readonly ProgramingLanguageBusinessRule _businessRule;
    private readonly IMapper _mapper;
    private readonly IProgramingLanguageRepo _programingLanguageRepo;

    public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepo programingLanguageRepo,
        ProgramingLanguageBusinessRule businessRule, IMapper mapper)
    {
        _programingLanguageRepo = programingLanguageRepo;
        _businessRule = businessRule;
        _mapper = mapper;
    }


    public async Task<UpdatedProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request,
        CancellationToken cancellationToken)
    {
        var programingLanguage = await _programingLanguageRepo.GetAsync(pl => pl.Id == request.Id);
        _businessRule.ProgramingLanguageShouldBeExistWhenUpdated(programingLanguage);
        await _businessRule.ProgramingLanguageCanNotBeDuplicatedWhenUpdated(request.Name, request.Id);
        _mapper.Map(request, programingLanguage);
        var updatedProgramingLanguage = await _programingLanguageRepo.UpdateAsync(programingLanguage!);
        var updatedProgramingLanguageDto =
            _mapper.Map<UpdatedProgramingLanguageDto>(updatedProgramingLanguage);
        return updatedProgramingLanguageDto;
    }
}