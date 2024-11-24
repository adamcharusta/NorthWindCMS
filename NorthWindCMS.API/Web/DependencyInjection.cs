using NorthWindCMS.API.Web.Infrastructure;

namespace NorthWindCMS.API.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddOpenApi();

        return services;
    }

    public static WebApplication UseWeb(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.MapEndpoints();
        app.UseExceptionHandler(options => { });

        return app;
    }
}
