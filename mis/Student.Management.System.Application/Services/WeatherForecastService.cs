using Student.Management.System.Application.Ports.In;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private IWeatherForecastRepository weatherForecastRepository;

    public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
    {
        this.weatherForecastRepository = weatherForecastRepository;
    }

    public IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        return weatherForecastRepository.GetWeatherForecasts();
    }
}
