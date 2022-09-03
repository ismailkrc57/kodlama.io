using Application.Features.ProgramingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgramingLanguages.Rules;

public class ProgramingLanguageBusinessRule
{
    public ProgramingLanguageBusinessRule(IProgramingLanguageRepo programingLanguageRepo)
    {
        _programingLanguageRepo = programingLanguageRepo;
    }

    private IProgramingLanguageRepo _programingLanguageRepo { get; }

    public async Task ProgramingLanguageCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<ProgramingLanguage> result = await _programingLanguageRepo.GetListAsync(pl => pl.Name == name);
        if (result.Items.Any())
            throw new BusinessException(Messages.NameAlreadyExist);
    }

    public void ProgramingLanguageShouldBeExistWhenRequested(ProgramingLanguage? programingLanguage)
    {
        if (programingLanguage == null) throw new BusinessException(Messages.ProgramingLanguageNotFound);
    }
}