using Application.Features.Users.Dto;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public class UserGetByIdQuery : IRequest<UserGetByIdDto>

{
    public int Id { get; set; }
}