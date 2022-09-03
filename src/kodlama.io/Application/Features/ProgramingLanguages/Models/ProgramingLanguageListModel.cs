using Application.Features.ProgramingLanguages.Dto;
using Core.Persistence.Paging;

namespace Application.Features.ProgramingLanguages.Models;

public  class ProgramingLanguageListModel:BasePageableModel
{
    public IList<ProgramingLanguageListDto> Items { get; set; }
}