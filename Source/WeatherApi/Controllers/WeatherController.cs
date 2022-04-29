using Microsoft.AspNetCore.Mvc;
using WeatherApiProject.Configuration;

namespace WeatherApiProject.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
       private readonly WeatherConfiguration weatherConfiguration;

    public WeatherController(WeatherConfiguration weatherConfiguration)
    {
        this.weatherConfiguration = weatherConfiguration;
    }

    [HttpGet]
    public WeatherResponse Get()
    {
        Console.WriteLine($"{DateTimeOffset.Now} - Received Get request");

        return GetRandomWeahterResponse();
    }

    private WeatherResponse GetRandomWeahterResponse()
    { 
        var weatherTypes = new[] { "sunny", "cloudy", "raining", "snowing" };
        var random = new Random(DateTime.Now.Millisecond);
        var randomWeather = weatherTypes[random.Next(0, weatherTypes.Length)];
        var randomTemperature = random.Next(0, 31);

        return new WeatherResponse
        {
            City = this.weatherConfiguration.City,
            Weather = randomWeather,
            Temperature = randomTemperature,
            TemperatureUnit = this.weatherConfiguration.TemperatureUnit
        };
    }
}
