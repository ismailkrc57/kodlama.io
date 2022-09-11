using Application.Features.Users.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Users.Queries.GetList;

public class UserGetListQuery : IRequest<UserListModel>

{
    public PageRequest PageRequest { get; set; }
}