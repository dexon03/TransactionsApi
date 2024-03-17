using Microsoft.Extensions.DependencyInjection;
using Transaction.Application.Abstractions;
using Transaction.Application.Services;

namespace Transaction.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
        });
        services.AddScoped<ITimeZoneService, TimeZoneService>();
        return services;
    }
    
}