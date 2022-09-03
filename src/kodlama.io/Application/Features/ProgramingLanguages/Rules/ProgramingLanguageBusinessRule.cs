using Application.Features.ProgramingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
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
        var result = await _programingLanguageRepo.GetListAsync(pl => pl.Name == name);
        if (result.Items.Any())
            throw new BusinessException(Messages.NameAlreadyExist);
    }

    public void ProgramingLanguageShouldBeExistWhenRequested(ProgramingLanguage? programingLanguage)
    {
        if (programingLanguage == null) throw new BusinessException(Messages.ProgramingLanguageNotFound);
    }

    public void ProgramingLanguageShouldBeExistWhenDeleted(ProgramingLanguage? programingLanguage)
    {
        if (programingLanguage == null) throw new BusinessException(Messages.ProgramingLanguageNotFound);
    }

    public void ProgramingLanguageShouldBeExistWhenUpdated(ProgramingLanguage? programingLanguage)
    {
        if (programingLanguage == null) throw new BusinessException(Messages.ProgramingLanguageNotFound);
    }

    public async Task ProgramingLanguageCanNotBeDuplicatedWhenUpdated(string name, int id)
    {
        var result =
            await _programingLanguageRepo.GetListAsync(pl => pl.Name == name && pl.Id != id);
        if (result.Items.Any())
            throw new BusinessException(Messages.NameAlreadyExist);
    }
}