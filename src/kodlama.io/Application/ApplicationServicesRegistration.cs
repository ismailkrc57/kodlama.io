using System.Reflection;
using Application.Features.ProgramingLanguages.Rules;
using Application.Features.Technologies.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection collection)
    {
        collection.AddAutoMapper(Assembly.GetExecutingAssembly());
        collection.AddMediatR(Assembly.GetExecutingAssembly());
        collection.AddScoped<ProgramingLanguageBusinessRule>();
        collection.AddScoped<TechnologyBusinessRule>();
        collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        collection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        return collection;
    }
}