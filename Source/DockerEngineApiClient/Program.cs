using Docker.DotNet;
using DockerEngineApiClient.Configuration;
using DockerEngineApiClient.Extensions;
using Serilog;
using System.Reactive.Linq;

namespace DockerEngineApiClient;

public static class Program
{
    #region Private Fields

    private static Dictionary<string, DockerContainerStatsWriter> DockerContainerCsvFileWriters;
    private static List<DockerContainerMonitor> DockerContainerMonitors;

    #endregion Private Fields

    #region Public Methods

    public static async Task Main(string[] args)
    {
        // configuration
        var configuration = "./appsettings.json".GetConfiguration();
        var dockerMontainerMonitoringConfiguration = configuration.GetDockerContainerMonitoringConfiguration();
        var clock = new Clock();
        var logger = configuration.ConfigureLogging();

        logger.LogExceptions();

        logger.Information("Starting docker container monitor");

        DockerContainerCsvFileWriters = dockerMontainerMonitoringConfiguration.Containers.ToDictionary(c => c.Key, c => new DockerContainerStatsWriter(c.Value));
        DockerContainerMonitors = GetDockerContainerMonitors(dockerMontainerMonitoringConfiguration, clock, logger).ToList();

        await Task.WhenAll(DockerContainerMonitors.Select(dcm => dcm.StartAsync()).ToArray());

        DockerContainerMonitors.ForEach(dcm => dcm.Dispose());
    }

    #endregion Public Methods

    #region Private Methods

    private static IEnumerable<DockerContainerMonitor> GetDockerContainerMonitors(DockerContainerMonitoringConfiguration dockerContainerMonitoringConfiguration, IClock clock, ILogger logger)
    {
        var dockerContainerMonitors = new List<DockerContainerMonitor>();
        var dockerClient = new DockerClientConfiguration(dockerContainerMonitoringConfiguration.Docker.Uri).CreateClient();

        foreach (var mapping in dockerContainerMonitoringConfiguration.Containers)
        {
            var dockerContainerName = mapping.Key;
            var dockerContainerMonitor = new DockerContainerMonitor(dockerClient, dockerContainerName, clock, logger);

            dockerContainerMonitor.DockerContainerStatReceived.Subscribe(async stats => await OnStatsReceivedAsync(mapping.Key, stats).ConfigureAwait(false));
            dockerContainerMonitors.Add(dockerContainerMonitor);
        }

        return dockerContainerMonitors;
    }

    private static void LogExceptions(this ILogger logger)
    {
        // log unhandled exceptions
        TaskScheduler.UnobservedTaskException += (_, e) => logger.Error("Unobserved task exception occurred.", e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (_, e) => logger.Error("Unhandled exception occurred.", e.ExceptionObject as Exception);
    }

    private static async Task OnStatsReceivedAsync(string dockerContainerId, DockerContainerStats stats)
    {
        await DockerContainerCsvFileWriters[dockerContainerId].Write(stats).ConfigureAwait(false);
    }

    #endregion Private Methods
}