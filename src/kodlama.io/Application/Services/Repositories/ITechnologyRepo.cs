using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITechnologyRepo : IAsyncRepository<Technology>, IRepository<Technology>
{
}