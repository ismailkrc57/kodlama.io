using Application.Features.GithubAccounts.Commands.Create;
using Application.Features.GithubAccounts.Dto;
using Application.Features.GithubAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.CommandHandlers;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreatedAccountDto>

{
    private readonly IMapper _mapper;
    private readonly IGithubAccountRepo _githubAccountRepo;
    private readonly AccountBusinessRule _accountBusinessRule;

    public CreateAccountCommandHandler(IMapper mapper, IGithubAccountRepo githubAccountRepo,
        AccountBusinessRule accountBusinessRule)
    {
        _mapper = mapper;
        _githubAccountRepo = githubAccountRepo;
        _accountBusinessRule = accountBusinessRule;
    }

    public async Task<CreatedAccountDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountBusinessRule.GithubAccountCannotBeDuplicated(request.Url);
        var mappedAccount = _mapper.Map<GithubAccount>(request);
        var createdAccount = await _githubAccountRepo.AddAsync(mappedAccount);
        return _mapper.Map<CreatedAccountDto>(createdAccount);
    }
}