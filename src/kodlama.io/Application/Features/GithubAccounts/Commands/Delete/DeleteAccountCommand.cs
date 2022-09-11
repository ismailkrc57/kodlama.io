using Application.Features.GithubAccounts.Dto;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.Delete;

public class DeleteAccountCommand : IRequest<DeletedAccountDto>
{
    public int Id { get; set; }
}