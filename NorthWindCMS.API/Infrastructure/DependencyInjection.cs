using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWindCMS.API.Infrastructure.Data;

namespace NorthWindCMS.API.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDataServices(configuration);
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseData();
        return app;
    }
}
