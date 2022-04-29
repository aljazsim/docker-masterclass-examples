namespace WeatherApiProject.Controllers;

public class WeatherResponse
{
    public string City { get; set; }
    public int Temperature { get; set; }
    public string TemperatureUnit { get; set; }
    public string Weather { get; set; }
}
