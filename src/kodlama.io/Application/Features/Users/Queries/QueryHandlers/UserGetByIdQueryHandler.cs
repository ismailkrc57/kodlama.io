using Application.Features.Users.Dto;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries.QueryHandlers;

public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserGetByIdDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;
    private readonly UserBusinessRule _businessRule;

    public UserGetByIdQueryHandler(IMapper mapper, IUserRepo userRepo, UserBusinessRule businessRule)
    {
        _mapper = mapper;
        _userRepo = userRepo;
        _businessRule = businessRule;
    }

    public async Task<UserGetByIdDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepo.GetAsync(u => u.Id == request.Id);
        _businessRule.UserMustBeExist(user);
        var userDto = _mapper.Map<UserGetByIdDto>(user);
        return userDto;
    }
}