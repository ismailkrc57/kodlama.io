using Application.Features.Auth.Command.Register;
using Application.Features.Auth.Dto;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Command.CommandHandlers;

public class RegisterCommandHandlers : IRequestHandler<RegisterCommand, RegisteredUserDto>
{
    private IUserRepo _userRepo;
    private IMapper _mapper;
    private AuthBusinessRule _authBusinessRule;

    public RegisterCommandHandlers(IUserRepo userRepo, IMapper mapper,
        AuthBusinessRule authBusinessRule)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _authBusinessRule = authBusinessRule;
    }

    public async Task<RegisteredUserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRule.EmailCannotBeDuplicatedWhenRegistering(request.UserForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
        User user = new User
        {
            Email = request.UserForRegisterDto.Email,
            FirstName = request.UserForRegisterDto.FirstName,
            LastName = request.UserForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        var addedUser = await _userRepo.AddAsync(user);
        var userToReturn = _mapper.Map<RegisteredUserDto>(addedUser);
        return userToReturn;
    }
}