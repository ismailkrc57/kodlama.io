using Application.Features.GithubAccounts.Dto;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.Update;

public class UpdateAccountCommand : IRequest<UpdatedAccountDto>
{
    public int Id { get; set; }
    public string Url { get; set; }
}