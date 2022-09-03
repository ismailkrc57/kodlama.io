using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
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
        var programingLanguages =
            await _programingLanguageRepo.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var model = _mapper.Map<ProgramingLanguageListModel>(programingLanguages);
        return model;
    }
}