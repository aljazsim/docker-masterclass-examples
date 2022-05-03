using Microsoft.Extensions.Configuration;
using Serilog;

namespace DockerEngineApiClient.Extensions;

public static class LoggingExtensions
{
    #region Public Methods

    public static ILogger ConfigureLogging(this IConfiguration configuration)
    {
        return new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
    }

    #endregion Public Methods
}
