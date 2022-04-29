using WeatherApiProject.Configuration;
using WeatherApiProject;
using Serilog;
using Serilog.Core;

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
        // add controllers
        builder.Services.AddControllers();

        // add configuration
        builder.Services.AddSingleton(builder.Configuration.GetConfiguration<WeatherConfiguration>());
        
        // add logger
        builder.Services.AddSingleton(ConfigureLogging(builder.Configuration));

        // add cors
        builder.Services.AddCors(options => options.AddPolicy("default", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
    }

    public static void ConfigureApplication(WebApplicationBuilder builder)
    {
        var app = builder.Build();

        app.UseCors("default");
        app.MapControllers();
        app.Run();
    }

    public static Logger ConfigureLogging(this IConfiguration configuration)
    {
        return new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
    }
}
