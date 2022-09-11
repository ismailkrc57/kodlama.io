using Application.Features.Users.Command.Update;
using Application.Features.Users.Dto;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Command.CommandHandlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;
    private readonly UserBusinessRule _userBusinessRule;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepo userRepo, UserBusinessRule userBusinessRule)
    {
        _mapper = mapper;
        _userRepo = userRepo;
        _userBusinessRule = userBusinessRule;
    }

    public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepo.GetAsync(u => u.Id == request.Id);
        _userBusinessRule.UserMustBeExist(user);
        var mappedUser = _mapper.Map(request, user);
        _userBusinessRule.UserMustBeExist(mappedUser);
        await _userBusinessRule.EmailMustBeUniqueWhenUpdatedUser(request.Email, request.Id);
        var updatedUser = await _userRepo.UpdateAsync(mappedUser!);
        return _mapper.Map<UpdatedUserDto>(updatedUser);
    }
}