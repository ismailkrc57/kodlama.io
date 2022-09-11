using Application.Features.GithubAccounts.Models;
using Application.Features.GithubAccounts.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.GithubAccounts.Queries.QueryHandlers;

public class AccountListQueryHandler : IRequestHandler<AccountListQuery, AccountListModel>
{
    private readonly IGithubAccountRepo _accountRepo;
    private readonly IMapper _mapper;

    public AccountListQueryHandler(IGithubAccountRepo accountRepo, IMapper mapper)
    {
        _accountRepo = accountRepo;
        _mapper = mapper;
    }

    // TODO: Map to AccountListModel
    public async Task<AccountListModel> Handle(AccountListQuery request, CancellationToken cancellationToken)
    {
        var accounts = await _accountRepo.GetListAsync(cancellationToken: cancellationToken,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        var accountListModel = _mapper.Map<AccountListModel>(accounts);
        return accountListModel;
    }
}