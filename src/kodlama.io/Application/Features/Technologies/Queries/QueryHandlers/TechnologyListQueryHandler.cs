using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.QueryHandlers;

public class TechnologyListQueryHandler : IRequestHandler<TechnologyListQuery, TechnologyListModel>
{
    private readonly ITechnologyRepo _technologyRepo;
    private readonly IMapper _mapper;

    public TechnologyListQueryHandler(ITechnologyRepo technologyRepo, IMapper mapper)
    {
        _technologyRepo = technologyRepo;
        _mapper = mapper;
    }


    public async Task<TechnologyListModel> Handle(TechnologyListQuery request, CancellationToken cancellationToken)
    {
        var technologies =
            await _technologyRepo.GetListAsync(
                size: request.PageRequest.PageSize,
                index: request.PageRequest.Page,
                cancellationToken: cancellationToken,
                include: t => t.Include(c => c.ProgramingLanguage)!);
        var technologyListModel = _mapper.Map<TechnologyListModel>(technologies);
        return technologyListModel;
    }
}