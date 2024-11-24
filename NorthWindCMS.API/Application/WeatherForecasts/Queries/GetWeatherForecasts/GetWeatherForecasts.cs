namespace NorthWindCMS.API.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public record GetWeatherForecastsQuery : IRequest<List<WeatherForecast>>;

public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, List<WeatherForecast>>
{
    public async Task<List<WeatherForecast>> Handle(GetWeatherForecastsQuery request,
        CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = WeatherSummary.GetSummary(Random.Shared.Next(WeatherSummary.GetSummariesLength()))
                })
            .ToList();

        return await Task.FromResult(forecast);
    }
}
