using NorthWindCMS.API.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using NorthWindCMS.API.Web.Infrastructure;

namespace NorthWindCMS.API.Web.Endpoints;

public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetWeatherForecasts);
    }

    private async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }
}
