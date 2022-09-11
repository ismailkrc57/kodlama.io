using Application.Features.Auth.Dto;
using Core.Security.Dtos;
using MediatR;

namespace Application.Features.Auth.Command.Register;

public class RegisterCommand : IRequest<RegisteredUserDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
}