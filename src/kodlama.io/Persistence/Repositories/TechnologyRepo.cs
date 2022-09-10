using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class TechnologyRepo : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepo
{
    public TechnologyRepo(BaseDbContext context) : base(context)
    {
    }
}