using Application.Features.Users.Command.Delete;
using Application.Features.Users.Dto;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Command.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;
    private readonly UserBusinessRule _userBusinessRule;

    public DeleteUserCommandHandler(IMapper mapper, IUserRepo userRepo, UserBusinessRule userBusinessRule)
    {
        _mapper = mapper;
        _userRepo = userRepo;
        _userBusinessRule = userBusinessRule;
    }

    public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepo.GetAsync(u => u.Id == request.Id);
        _userBusinessRule.UserMustBeExist(user);
        var deletedUser = _userRepo.Delete(user!);
        return _mapper.Map<DeletedUserDto>(deletedUser);
    }
}