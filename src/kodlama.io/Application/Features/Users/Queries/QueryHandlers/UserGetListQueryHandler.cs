using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetList;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries.QueryHandlers;

public class UserGetListQueryHandler : IRequestHandler<UserGetListQuery, UserListModel>
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;
    private readonly UserBusinessRule _userBusinessRule;

    public UserGetListQueryHandler(IMapper mapper, IUserRepo userRepo, UserBusinessRule userBusinessRule)
    {
        _mapper = mapper;
        _userRepo = userRepo;
        _userBusinessRule = userBusinessRule;
    }

    public async Task<UserListModel> Handle(UserGetListQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepo.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);
        var model = _mapper.Map<UserListModel>(users);
        return model;
    }
}