using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Ports.Out;

public interface IWeatherForecastRepository
{
    IEnumerable<WeatherForecast> GetWeatherForecasts();
}
