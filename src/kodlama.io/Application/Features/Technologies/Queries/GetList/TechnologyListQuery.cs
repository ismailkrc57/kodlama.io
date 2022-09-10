using Application.Features.Technologies.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Technologies.Queries.GetList;

public class TechnologyListQuery : IRequest<TechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
}