using Application.Features.GithubAccounts.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.GithubAccounts.Rules;

public class AccountBusinessRule
{
    private readonly IGithubAccountRepo _githubAccountRepo;

    public AccountBusinessRule(IGithubAccountRepo githubAccountRepo)
    {
        _githubAccountRepo = githubAccountRepo;
    }

    public async Task GithubAccountCannotBeDuplicated(string url)
    {
        var account = await _githubAccountRepo.GetAsync(ga => ga.Url == url);
        if (account != null)
        {
            throw new BusinessException(Messages.AccountAlreadyExists);
        }
    }

    public void GithubAccountMustExist(GithubAccount? account)
    {
        if (account == null)
        {
            throw new BusinessException(Messages.AccountNotFound);
        }
    }

    public async Task GithubAccountCanNotBeDuplicatedWhenUpdated(string url, int id)
    {
        var account = await _githubAccountRepo.GetAsync(ga => ga.Url == url && ga.Id != id);
        if (account != null)
        {
            throw new BusinessException(Messages.AccountAlreadyExists);
        }
    }
}