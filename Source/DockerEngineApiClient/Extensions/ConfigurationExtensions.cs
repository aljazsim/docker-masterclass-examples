using DockerEngineApiClient.Configuration;
using Microsoft.Extensions.Configuration;

namespace DockerEngineApiClient.Extensions
{
    public static class ConfigurationExtensions
    {
        #region Public Methods

        public static DockerContainerMonitoringConfiguration GetDockerContainerMonitoringConfiguration(this IConfigurationRoot configuration)
        {
            return configuration.GetConfiguration<DockerContainerMonitoringConfiguration>();
        }

        public static T GetConfiguration<T>(this IConfigurationRoot configuration) where T : class, new()
        {
            return configuration.GetSection(typeof(T).Name.Replace("Configuration", string.Empty)).Get<T>() ?? new();
        }

        public static IConfigurationRoot GetConfiguration(this string configurationFilePath)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Path.GetFullPath(Path.GetDirectoryName(configurationFilePath)));
            builder.AddJsonFile(Path.GetFileName(configurationFilePath), true, false);
            builder.AddEnvironmentVariables();

            return builder.Build();
        }

        #endregion Public Methods
    }
}