using Application.Features.ProgramingLanguages.Commands.Create;
using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetById;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgramingLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgramingLanguage, CreatedProgramingLanguageDto>().ReverseMap();
        CreateMap<ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();
        CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
        CreateMap<ProgramingLanguage, ProgramingLanguageListDto>().ReverseMap();
        CreateMap<ProgramingLanguage, GetByIdProgramingLanguageDto>().ReverseMap();
    }
}