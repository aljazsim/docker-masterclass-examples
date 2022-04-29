using WeatherApiProject.Configuration;
using WeatherApiProject;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder);
        ConfigureApplication(builder);
    }

    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddSingleton(builder.Configuration.GetConfiguration<WeatherConfiguration>());
    }

    public static void ConfigureApplication(WebApplicationBuilder builder)
    {
        var app = builder.Build();

        app.MapControllers();
        app.Run();
    }
}
