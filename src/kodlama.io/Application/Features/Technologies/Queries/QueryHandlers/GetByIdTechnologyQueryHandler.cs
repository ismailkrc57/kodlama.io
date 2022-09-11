using Application.Features.Technologies.Dto;
using Application.Features.Technologies.Queries.GetById;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.QueryHandlers;

public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
{
    private readonly ITechnologyRepo _technologyRepo;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRule _technologyBusinessRule;

    public GetByIdTechnologyQueryHandler(ITechnologyRepo technologyRepo, IMapper mapper,
        TechnologyBusinessRule technologyBusinessRule)
    {
        _technologyRepo = technologyRepo;
        _mapper = mapper;
        _technologyBusinessRule = technologyBusinessRule;
    }


    public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRule.TechnologyMustBeExistWhenGetTechnology(request.Id);
        var technology = await _technologyRepo.Query().Include(t => t.ProgramingLanguage)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        var technologyDto = _mapper.Map<GetByIdTechnologyDto>(technology);
        return technologyDto;
    }
}