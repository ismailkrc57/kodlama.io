using Application.Features.Technologies.Commands.Create;
using Application.Features.Technologies.Commands.Update;
using Application.Features.Technologies.Dto;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
        CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
        CreateMap<Technology, TechnologyListDto>()
            .ForMember(t => t.ProgrammingLanguage, opt => opt.MapFrom(t => t.ProgramingLanguage!.Name)).ReverseMap();
        CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
        CreateMap<Technology, UpdatedTechnologyDto>()
            .ForMember(t => t.ProgramingLanguage, opt => opt.MapFrom(t => t.ProgramingLanguage!.Name)).ReverseMap();

        CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
        CreateMap<Technology, GetByIdTechnologyDto>()
            .ForMember(t => t.ProgrammingLanguage,
                opt => opt.MapFrom(
                    t => t.ProgramingLanguage!.Name)).ReverseMap();
    }
}