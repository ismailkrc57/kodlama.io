using Application.Features.GithubAccounts.Commands.Delete;
using Application.Features.GithubAccounts.Dto;
using Application.Features.GithubAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.CommandHandlers;

public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, DeletedAccountDto>
{
    private readonly IMapper _mapper;
    private readonly IGithubAccountRepo _githubAccountRepo;
    private readonly AccountBusinessRule _accountBusinessRule;

    public DeleteAccountCommandHandler(IMapper mapper, IGithubAccountRepo githubAccountRepo,
        AccountBusinessRule accountBusinessRule)
    {
        _mapper = mapper;
        _githubAccountRepo = githubAccountRepo;
        _accountBusinessRule = accountBusinessRule;
    }

    public async Task<DeletedAccountDto> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _githubAccountRepo.GetAsync(ga => ga.Id == request.Id);
        _accountBusinessRule.GithubAccountMustExist(account);
        var deletedAccount = await _githubAccountRepo.DeleteAsync(account!);
        return _mapper.Map<DeletedAccountDto>(deletedAccount);
    }
}