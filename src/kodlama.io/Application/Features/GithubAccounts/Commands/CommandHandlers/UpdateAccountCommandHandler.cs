using Application.Features.GithubAccounts.Commands.Update;
using Application.Features.GithubAccounts.Dto;
using Application.Features.GithubAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.CommandHandlers;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdatedAccountDto>
{
    private readonly IMapper _mapper;
    private readonly IGithubAccountRepo _githubAccountRepo;
    private readonly AccountBusinessRule _accountBusinessRule;

    public UpdateAccountCommandHandler(IMapper mapper, IGithubAccountRepo githubAccountRepo,
        AccountBusinessRule accountBusinessRule)
    {
        _mapper = mapper;
        _githubAccountRepo = githubAccountRepo;
        _accountBusinessRule = accountBusinessRule;
    }

    public async Task<UpdatedAccountDto> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountBusinessRule.GithubAccountCanNotBeDuplicatedWhenUpdated(request.Url, request.Id);
        var account = await _githubAccountRepo.GetAsync(ga => ga.Id == request.Id);
        _accountBusinessRule.GithubAccountMustExist(account);
        var mappedAccount = _mapper.Map(request, account);
        var updatedAccount = await _githubAccountRepo.UpdateAsync(mappedAccount);
        var updatedAccountDto = _mapper.Map<UpdatedAccountDto>(updatedAccount);
        return updatedAccountDto;
    }
}