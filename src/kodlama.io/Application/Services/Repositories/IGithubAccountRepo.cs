using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IGithubAccountRepo : IRepository<GithubAccount>, IAsyncRepository<GithubAccount>
{
}