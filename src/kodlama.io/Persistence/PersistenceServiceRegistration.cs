using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServiceCollection(this IServiceCollection collection,
        IConfiguration configuration)
    {
        collection.AddDbContext<BaseDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("KodlamaIoConnectionString") ?? string.Empty);
        });
        collection.AddScoped<IProgramingLanguageRepo, ProgramingLanguageRepo>();
        collection.AddScoped<ITechnologyRepo, TechnologyRepo>();
        collection.AddScoped<IUserRepo, UserRepo>();
        collection.AddScoped<IGithubAccountRepo, GithubAccountRepo>();
        return collection;
    }
}