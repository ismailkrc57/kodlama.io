using Application.Features.ProgramingLanguages.Commands.Delete;
using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.CommandHandlers;

public class
    DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand,
        DeletedProgramingLanguageDto>
{
    private readonly ProgramingLanguageBusinessRule _businessRule;
    private readonly IMapper _mapper;
    private readonly IProgramingLanguageRepo _programingLanguageRepo;

    public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepo programingLanguageRepo,
        ProgramingLanguageBusinessRule businessRule, IMapper mapper)
    {
        _programingLanguageRepo = programingLanguageRepo;
        _businessRule = businessRule;
        _mapper = mapper;
    }


    public async Task<DeletedProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request,
        CancellationToken cancellationToken)
    {
        var programingLanguage = await _programingLanguageRepo.GetAsync(pl => pl.Id == request.Id);
        _businessRule.ProgramingLanguageShouldBeExistWhenDeleted(programingLanguage);
        var deletedProgramingLanguage = await _programingLanguageRepo.DeleteAsync(programingLanguage);
        var deletedProgramingLanguageDto =
            _mapper.Map<DeletedProgramingLanguageDto>(deletedProgramingLanguage);
        return deletedProgramingLanguageDto;
    }
}