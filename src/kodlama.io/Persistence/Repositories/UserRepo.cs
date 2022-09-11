using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserRepo : EfRepositoryBase<User, BaseDbContext>, IUserRepo
{
    public UserRepo(BaseDbContext context) : base(context)
    {
    }
}