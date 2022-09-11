using Application.Features.GithubAccounts.Dto;
using Application.Features.GithubAccounts.Models;
using MediatR;

namespace Application.Features.GithubAccounts.Queries.GetById;

public class GetByIdAccountQuery : IRequest<GetByIdAccountDto>
{
    public int Id { get; set; }
}