using Application.Features.Users.Dto;
using MediatR;

namespace Application.Features.Users.Command.Update;

public class UpdateUserCommand:IRequest<UpdatedUserDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
}