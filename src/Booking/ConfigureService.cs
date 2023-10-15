using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Helpers.HealthCheck;
using Booking.Helpers.NSwag;
using Booking.Middleware;
using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors.Security;

namespace Booking;

public static class ConfigureService
{
    public static IServiceCollection AddComponentService(this IServiceCollection services,
    IConfiguration configuration, string environmentName)
    {
        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddCheck<AliveHealthCheck>("alive", tags: new[] { "alive" });

        services.AddCors(options =>
        {
            options.AddPolicy("CORS", policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        });

        services.AddOpenApiDocument(config =>
        {
            config.Title = "Booking API";
            config.Version = "v1";
            config.Description = $"Booking API {environmentName}";
            config.OperationProcessors.Add(new AddRequiredHeaderParameter());
        });

        //Middleware
        services.AddTransient<RequestHeaderMiddleware>();

        return services;
    }
}
