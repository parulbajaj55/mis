using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> logger;
    private IWeatherForecastService weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService, ILogger<WeatherForecastController> logger)
    {
        this.logger = logger;
        this.weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return weatherForecastService.GetWeatherForecasts();
    }
}
