﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raven.DependencyInjection;
using Search.Application.Validations;

namespace Search.Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            options.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        builder.Services.AddRavenDbAsyncSession();
        builder.Services.AddRavenDbSession();

        builder.Services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return builder;
    }
}