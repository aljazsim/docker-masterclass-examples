using System.Reflection;

namespace WeatherApiProject;

public static class ConfigurationExtensions
{
    public static T GetConfiguration<T>(this IConfigurationRoot configuration) where T : class, new()
    {
        return configuration.GetSection(typeof(T).Name.Replace("Configuration", string.Empty)).Get<T>() ?? new();
    }

    public static IConfigurationRoot GetConfiguration(this string configurationFilePath)
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(Path.GetDirectoryName(configurationFilePath));
        builder.AddJsonFile(Path.GetFileName(configurationFilePath), true, false);
        builder.AddEnvironmentVariables();

        return builder.Build();
    }
}
