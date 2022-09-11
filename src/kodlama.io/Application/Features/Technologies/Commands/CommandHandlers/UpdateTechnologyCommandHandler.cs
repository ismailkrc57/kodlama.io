using Application.Features.Technologies.Commands.Create;
using Application.Features.Technologies.Commands.Update;
using Application.Features.Technologies.Dto;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CommandHandlers;

public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
{
    private readonly ITechnologyRepo _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRule _technologyBusinessRule;

    public UpdateTechnologyCommandHandler(ITechnologyRepo technologyRepository, IMapper mapper,
        TechnologyBusinessRule technologyBusinessRule)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRule = technologyBusinessRule;
    }


    public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
    {
        var technology = await _technologyRepository.GetAsync(t => t.Id == request.TechnologyId);
        _technologyBusinessRule.TechnologyMustBeExistWhenUpdateTechnology(technology);
        await _technologyBusinessRule.ProgramingLanguageMustBeExistWhenInsertTechnology(request.ProgramingLanguageId);
        await _technologyBusinessRule.TechnologyNameMustBeUniqueWhenUpdateTechnology(request.TechnologyId,
            request.Name);
        _mapper.Map(request, technology);
        var updatedTechnology = _technologyRepository.Update(technology!);
        var updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
        return updatedTechnologyDto;
    }
}