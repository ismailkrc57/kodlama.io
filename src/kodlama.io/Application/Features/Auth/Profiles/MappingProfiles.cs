using Application.Features.Auth.Dto;
using Application.Features.ProgramingLanguages.Commands.Create;
using Application.Features.ProgramingLanguages.Commands.Delete;
using Application.Features.ProgramingLanguages.Commands.Update;
using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Auth.Constants;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, RegisteredUserDto>().ReverseMap();
    }
}