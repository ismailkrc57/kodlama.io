using Application.Features.Technologies.Dto;
using MediatR;

namespace Application.Features.Technologies.Queries.GetById;

public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDto>
{
    public int Id { get; set; }
}