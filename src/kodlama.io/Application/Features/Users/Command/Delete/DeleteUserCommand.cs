using Application.Features.Users.Dto;
using MediatR;

namespace Application.Features.Users.Command.Delete;

public class DeleteUserCommand : IRequest<DeletedUserDto>
{
    public int Id { get; set; }
}