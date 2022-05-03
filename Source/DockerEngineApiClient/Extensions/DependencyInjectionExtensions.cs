using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DockerEngineApiClient.Extensions
{
    public static class DependencyInjectionExtensions
    {
        #region Public Methods

        public static IServiceProvider ConfigureServices(this IConfigurationRoot configuration)
        {
            // dependency injection
            var services = new ServiceCollection();

            return services.BuildServiceProvider();
        }

        #endregion Public Methods
    }
}