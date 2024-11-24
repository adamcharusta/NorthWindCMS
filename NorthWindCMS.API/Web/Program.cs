using NorthWindCMS.API.Application;
using NorthWindCMS.API.Infrastructure;
using NorthWindCMS.API.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    builder.Services
        .AddInfrastructureServices(builder.Configuration)
        .AddApplicationServices()
        .AddWebServices();

    var app = builder.Build();

    app
        .UseInfrastructure()
        .UseApplication()
        .UseWeb();

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandled exception");
}
finally
{
    await Log.CloseAndFlushAsync();
}

public partial class Program;
