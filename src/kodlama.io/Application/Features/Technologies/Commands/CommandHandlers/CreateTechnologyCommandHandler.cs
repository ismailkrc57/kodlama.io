using Application.Features.Technologies.Commands.Create;
using Application.Features.Technologies.Dto;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CommandHandlers;

public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
{
    private readonly ITechnologyRepo _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRule _technologyBusinessRule;

    public CreateTechnologyCommandHandler(ITechnologyRepo technologyRepository, IMapper mapper,
        TechnologyBusinessRule technologyBusinessRule)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRule = technologyBusinessRule;
    }


    public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRule.TechnologyNameMustBeUnique(request.Name);
        await _technologyBusinessRule.ProgramingLanguageMustBeExistWhenInsertTechnology(request.ProgramingLanguageId);
        var mappedTechnology = _mapper.Map<Technology>(request);
        var createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
        var mappedCreatedTechnology = _mapper.Map<CreatedTechnologyDto>(createdTechnology);
        return mappedCreatedTechnology;
    }
}