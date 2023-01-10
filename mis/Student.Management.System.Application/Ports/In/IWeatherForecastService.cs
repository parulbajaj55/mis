using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Ports.In
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}