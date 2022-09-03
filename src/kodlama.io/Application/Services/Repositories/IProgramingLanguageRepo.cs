using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IProgramingLanguageRepo : IAsyncRepository<ProgramingLanguage>, IRepository<ProgramingLanguage>
{
}