using Application.Features.ProgramingLanguages.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.ProgramingLanguages.Queries.GetList;

public class GetListProgramingLanguageQuery : IRequest<ProgramingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
}