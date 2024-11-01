using Basis.Desafio.TJRJ.Api.Exceptions;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Validators;
using Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Basis.Desafio.TJRJ.Api.Configurations;

public static class IoCConfig
{
    public static void ConfigureMigrations(string? defaultConnection) => new AppDbContextFactory().RunPendingMigrations(defaultConnection!);

    public static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddAuthorRequestValidator).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddValidatorsFromAssembly(typeof(AddAuthorRequestValidator).Assembly);
    }

    //Apagar
    public static void RegisterMediatr(this IServiceCollection services, string assemblystring)
    {
        var applicationAssembly = Assembly.Load(assemblystring);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddValidatorsFromAssembly(applicationAssembly);
    }
}