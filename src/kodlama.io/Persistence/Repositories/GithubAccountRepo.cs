using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class GithubAccountRepo : EfRepositoryBase<GithubAccount, BaseDbContext>, IGithubAccountRepo
{
    public GithubAccountRepo(BaseDbContext context) : base(context)
    {
    }
}