using Application.Features.GithubAccounts.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Features.GithubAccounts.Commands.Create;

public class CreateAccountCommand : IRequest<CreatedAccountDto>
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Url { get; set; }
}