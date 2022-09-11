using Application.Features.GithubAccounts.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.GithubAccounts.Queries.GetList;

public class AccountListQuery : IRequest<AccountListModel>
{
    public PageRequest PageRequest { get; set; }
}