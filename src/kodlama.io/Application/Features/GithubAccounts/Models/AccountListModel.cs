using Application.Features.GithubAccounts.Dto;
using Core.Persistence.Paging;

namespace Application.Features.GithubAccounts.Models;

public class AccountListModel : BasePageableModel
{
    public List<AccountListDto> Items { get; set; }
}