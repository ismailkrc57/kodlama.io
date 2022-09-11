using Application.Features.GithubAccounts.Commands.Create;
using Application.Features.GithubAccounts.Commands.Update;
using Application.Features.GithubAccounts.Dto;
using Application.Features.GithubAccounts.Models;
using Application.Features.Technologies.Commands.Create;
using Application.Features.Technologies.Commands.Update;
using Application.Features.Technologies.Dto;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.GithubAccounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GithubAccount, CreateAccountCommand>().ReverseMap();
        CreateMap<GithubAccount, UpdateAccountCommand>().ReverseMap();
        CreateMap<GithubAccount, CreatedAccountDto>().ReverseMap();
        CreateMap<GithubAccount, DeletedAccountDto>().ReverseMap();
        CreateMap<GithubAccount, UpdatedAccountDto>().ReverseMap();
        CreateMap<IPaginate<GithubAccount>, AccountListModel>().ReverseMap();
        CreateMap<GithubAccount, AccountListDto>()
            .ForMember(a => a.UserFirstName, opt => opt.MapFrom(ga => ga.User.FirstName))
            .ForMember(a => a.UserLastName, opt => opt.MapFrom(ga => ga.User.LastName))
            .ReverseMap();
        CreateMap<GithubAccount, GetByIdAccountDto>()
            .ForMember(a => a.UserFirstName, opt => opt.MapFrom(ga => ga.User.FirstName))
            .ForMember(a => a.UserLastName, opt => opt.MapFrom(ga => ga.User.LastName))
            .ReverseMap();
    }
}