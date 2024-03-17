using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transaction.Application.Abstractions;
using Transaction.Infrastructure.Csv;

namespace Transaction.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt 
            => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ICsvService, CsvService>();
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
        return services;
    }
    
}