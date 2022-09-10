using Application.Features.Technologies.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Technologies.Rules;

public class TechnologyBusinessRule
{
    private readonly ITechnologyRepo _technologyRepo;
    private readonly IProgramingLanguageRepo _programingLanguageRepo;

    public TechnologyBusinessRule(ITechnologyRepo technologyRepo, IProgramingLanguageRepo programingLanguageRepo)
    {
        _technologyRepo = technologyRepo;
        _programingLanguageRepo = programingLanguageRepo;
    }

    public async Task TechnologyNameMustBeUnique(string name)
    {
        var technology = await _technologyRepo.GetListAsync(t => t.Name == name);
        if (technology.Count >= 1)
        {
            throw new BusinessException(Messages.NameAlreadyExists);
        }
    }

    public async Task ProgramingLanguageMustBeExistWhenInsertTechnology(int programingLanguageId)
    {
        var programingLanguage = await _programingLanguageRepo.GetAsync(t => t.Id == programingLanguageId);
        if (programingLanguage == null)
        {
            throw new BusinessException(Messages.ProgramingLanguageMustBeExistWhenInsertTechnology);
        }
    }

    public async Task TechnologyNameMustBeUniqueWhenUpdateTechnology(int id, string name)
    {
        var technology = await _technologyRepo.GetAsync(t => t.Id != id && t.Name == name);
        if (technology != null)
        {
            throw new BusinessException(Messages.NameAlreadyExists);
        }
    }

    public void TechnologyMustBeExistWhenUpdateTechnology(Technology? technology)
    {
        if (technology == null)
        {
            throw new BusinessException(Messages.TechnologyNotFound);
        }
    }

    public void TechnologyMustBeExistWhenDeleteTechnology(Technology? technology)
    {
        if (technology == null)
        {
            throw new BusinessException(Messages.TechnologyNotFound);
        }
    }

    public async Task TechnologyMustBeExistWhenGetTechnology(int id)
    {
        var technology = await _technologyRepo.GetAsync(t => t.Id == id);
        if (technology == null)
        {
            throw new BusinessException(Messages.TechnologyNotFound);
        }
    }
}