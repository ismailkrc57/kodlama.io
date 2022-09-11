using Application.Features.GithubAccounts.Dto;
using Application.Features.GithubAccounts.Queries.GetById;
using Application.Features.GithubAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.GithubAccounts.Queries.QueryHandlers;

public class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQuery, GetByIdAccountDto>
{
    private readonly IGithubAccountRepo _accountRepository;
    private readonly IMapper _mapper;
    private readonly AccountBusinessRule _accountBusinessRule;

    public GetByIdAccountQueryHandler(IGithubAccountRepo accountRepository, IMapper mapper,
        AccountBusinessRule accountBusinessRule)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _accountBusinessRule = accountBusinessRule;
    }

    public async Task<GetByIdAccountDto> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(ga => ga.Id == request.Id);
        _accountBusinessRule.GithubAccountMustExist(account);
        var accountDto = _mapper.Map<GetByIdAccountDto>(account);
        return accountDto;
    }
}