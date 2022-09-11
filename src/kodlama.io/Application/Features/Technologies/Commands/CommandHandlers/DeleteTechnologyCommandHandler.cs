using Application.Features.Technologies.Commands.Delete;
using Application.Features.Technologies.Dto;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Technologies.Commands.CommandHandlers;

public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
{
    private readonly ITechnologyRepo _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRule _technologyBusinessRule;

    public DeleteTechnologyCommandHandler(ITechnologyRepo technologyRepository, IMapper mapper,
        TechnologyBusinessRule technologyBusinessRule)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRule = technologyBusinessRule;
    }


    public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
    {
        var technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);
        _technologyBusinessRule.TechnologyMustBeExistWhenDeleteTechnology(technology);
        var deletedTechnology = await _technologyRepository.DeleteAsync(technology!);
        var deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
        return deletedTechnologyDto;
    }
}