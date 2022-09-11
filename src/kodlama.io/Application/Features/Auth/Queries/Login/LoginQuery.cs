using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Queries.Login;

public class LoginQuery : IRequest<AccessToken>
{
    public UserForLoginDto UserForLoginDto { get; set; }
}