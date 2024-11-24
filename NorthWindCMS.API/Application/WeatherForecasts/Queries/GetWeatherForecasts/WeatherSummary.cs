namespace NorthWindCMS.API.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public static class WeatherSummary
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public static string GetSummary(int index)
    {
        if (index < 0 || index >= Summaries.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return Summaries[index];
    }

    public static int GetSummariesLength()
    {
        return Summaries.Length;
    }
}
