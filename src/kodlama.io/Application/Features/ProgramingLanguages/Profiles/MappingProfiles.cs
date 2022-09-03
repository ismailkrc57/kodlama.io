using Application.Features.ProgramingLanguages.Commands.Create;
using Application.Features.ProgramingLanguages.Commands.Delete;
using Application.Features.ProgramingLanguages.Commands.Update;
using Application.Features.ProgramingLanguages.Dto;
using Application.Features.ProgramingLanguages.Models;
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

        CreateMap<ProgramingLanguage, DeleteProgramingLanguageCommand>().ReverseMap();
        CreateMap<ProgramingLanguage, DeletedProgramingLanguageDto>().ReverseMap();
        CreateMap<ProgramingLanguage, UpdatedProgramingLanguageDto>().ReverseMap();
        CreateMap<ProgramingLanguage, UpdateProgramingLanguageCommand>().ReverseMap();
    }
}