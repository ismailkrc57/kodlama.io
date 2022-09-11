using Application.Features.Users.Command.Update;
using Application.Features.Users.Dto;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;


namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, DeletedUserDto>().ReverseMap();
        CreateMap<User, UpdatedUserDto>().ReverseMap();
        CreateMap<User, UserListDto>().ReverseMap();
        CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UserGetByIdDto>().ReverseMap();
    }
}