using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Queries.QueryHandlers;

public class
    GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
{
    private readonly IMapper _mapper;
    private readonly IProgramingLanguageRepo _programingLanguageRepo;

    public GetListProgramingLanguageQueryHandler(IMapper mapper, IProgramingLanguageRepo programingLanguageRepo)
    {
        _mapper = mapper;
        _programingLanguageRepo = programingLanguageRepo;
    }

    public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request,
        CancellationToken cancellationToken)
    {
        IPaginate<ProgramingLanguage> programingLanguages =
            await _programingLanguageRepo.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        ProgramingLanguageListModel model = _mapper.Map<ProgramingLanguageListModel>(programingLanguages);
        return model;
    }
}