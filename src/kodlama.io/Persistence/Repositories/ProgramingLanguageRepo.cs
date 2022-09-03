using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProgramingLanguageRepo : EfRepositoryBase<ProgramingLanguage, BaseDbContext>, IProgramingLanguageRepo
{
    public ProgramingLanguageRepo(BaseDbContext context) : base(context)
    {
    }
}