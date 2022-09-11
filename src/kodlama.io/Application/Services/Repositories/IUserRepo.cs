using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserRepo : IRepository<User>, IAsyncRepository<User>
{
}