using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NorthWindCMS.API.Infrastructure.Data;

internal static class DataDependencyInjection
{
    internal static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddHealthChecks()
            .AddDbContextCheck<AppDbContext>();

        services.AddSingleton(TimeProvider.System);

        return services;
    }

    internal static WebApplication UseData(this WebApplication app)
    {
        if (app.Environment.IsProduction())
        {
            app.UseHsts();
        }

        app.UseHealthChecks("/health");

        return app;
    }
}
