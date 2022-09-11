using Application.Features.Technologies.Dto;
using MediatR;

namespace Application.Features.Technologies.Commands.Delete;

public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
{
    public int Id { get; set; }
}