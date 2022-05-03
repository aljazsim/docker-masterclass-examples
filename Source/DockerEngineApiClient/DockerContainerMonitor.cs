using Docker.DotNet;
using Docker.DotNet.Models;
using Serilog;

namespace DockerEngineApiClient;

public class DockerContainerMonitor : IDisposable
{
    #region Private Fields

    private readonly DockerClient dockerClient;
    private readonly string dockerContainerName;
    private readonly DockerContainerStatsProgress dockerContainerStatsProgress;
    private readonly ILogger logger;
    private CancellationTokenSource cancellationTokenSource;
    private bool isDisposed = false;

    #endregion Private Fields

    #region Public Constructors

    public DockerContainerMonitor(DockerClient dockerClient, string dockerContainerName, IClock clock, ILogger logger)
    {
        this.dockerClient = dockerClient;
        this.dockerContainerName = dockerContainerName;
        this.dockerContainerStatsProgress = new DockerContainerStatsProgress(clock);
        this.logger = logger;
    }

    #endregion Public Constructors

    #region Public Properties

    public IObservable<DockerContainerStats> DockerContainerStatReceived => this.dockerContainerStatsProgress.DockerContainerStatsReceived;

    public bool IsRunning
    {
        get;
        private set;
    }

    #endregion Public Properties

    #region Public Methods

    public void Dispose()
    {
        if (!this.isDisposed)
        {
            this.isDisposed = true;
            this.IsRunning = false;

            this.cancellationTokenSource?.Cancel();
            this.cancellationTokenSource = null;

            this.dockerClient?.Dispose();
        }
    }

    public async Task StartAsync()
    {
        try
        {
            var dockerContainerId = await GetContainerIdAsync(this.dockerClient, this.dockerContainerName).ConfigureAwait(false);

            if (dockerContainerId != null)
            {
                this.logger.Information($"Start monitoring {this.dockerContainerName}.");

                this.IsRunning = true;

                this.cancellationTokenSource = new CancellationTokenSource();
                await this.dockerClient.Containers.GetContainerStatsAsync(this.dockerContainerName, new ContainerStatsParameters() { Stream = true }, this.dockerContainerStatsProgress, this.cancellationTokenSource.Token).ConfigureAwait(false);
            }
            else
            {
                this.logger.Warning($"Could not find container {this.dockerContainerName}");
            }
        }
        catch (Exception ex)
        {
            this.logger.Error($"Could not connect to Docker Engine API. {ex.Message} {ex.InnerException?.Message}", ex);
        }
    }

    public void Stop()
    {
        this.IsRunning = false;

        this.cancellationTokenSource?.Cancel();
        this.cancellationTokenSource = null;

        this.logger.Information($"Stop monitoring {this.dockerContainerName}.");
    }

    #endregion Public Methods

    #region Private Methods

    private static async Task<string> GetContainerIdAsync(DockerClient dockerClient, string dockerContainerName)
    {
        var parameters = new ContainersListParameters
        {
            Filters = new Dictionary<string, IDictionary<string, bool>>()
        };
        parameters.Filters.Add("name", new Dictionary<string, bool>());
        parameters.Filters["name"].Add(dockerContainerName, true);

        var containers = await dockerClient.Containers.ListContainersAsync(parameters).ConfigureAwait(false);

        foreach (var container in containers)
        {
            if (container.Names.Any(c => c.Trim('/') == dockerContainerName))
            {
                return container.ID;
            }
        }

        return null;
    }

    #endregion Private Methods
}