using Docker.DotNet.Models;
using System.Reactive.Subjects;

namespace DockerEngineApiClient
{
    public class DockerContainerStatsProgress : IProgress<ContainerStatsResponse>
    {
        #region Private Fields

        private readonly IClock clock;

        private readonly Subject<DockerContainerStats> dockerContainerStatsReceived = new Subject<DockerContainerStats>();

        #endregion Private Fields

        #region Public Constructors

        public DockerContainerStatsProgress(IClock clock)
        {
            this.clock = clock;
        }

        #endregion Public Constructors

        #region Public Properties

        public IObservable<DockerContainerStats> DockerContainerStatsReceived => this.dockerContainerStatsReceived;

        #endregion Public Properties

        #region Public Methods

        public void Report(ContainerStatsResponse stats)
        {
            var timestamp = this.clock.Now;
            var cpuUsagePercentage = CalculateCpuUsagePercentage(stats.PreCPUStats, stats.CPUStats);
            var memoryUsage = (long)stats.MemoryStats.Usage;
            var memoryUsageLimit = (long)(stats.MemoryStats.Limit > 0 ? stats.MemoryStats.Limit : stats.MemoryStats.MaxUsage);
            var memoryUsagePercentage = CalculateMemoryUsagePercentage(stats.MemoryStats);
            var storageReadBytes = (long)stats.StorageStats.ReadSizeBytes;
            var storageWriteBytes = (long)stats.StorageStats.WriteSizeBytes;
            var networkReadBytes = (long)stats.Networks.Values.DefaultIfEmpty().Sum(network => (long)network.RxBytes);
            var networkWriteBytes = (long)stats.Networks.Values.DefaultIfEmpty().Sum(network => (long)network.TxBytes);

            this.dockerContainerStatsReceived.OnNext(new DockerContainerStats(timestamp, cpuUsagePercentage, memoryUsage, memoryUsageLimit, memoryUsagePercentage, storageReadBytes, storageWriteBytes, networkReadBytes, networkWriteBytes));
        }

        #endregion Public Methods

        #region Private Methods

        private static double CalculateCpuUsagePercentage(CPUStats prevStats, CPUStats stats)
        {
            var cpuDelta = (long)stats.CPUUsage.TotalUsage - (long)prevStats.CPUUsage.TotalUsage;
            var systemDelta = (long)stats.SystemUsage - (long)prevStats.SystemUsage;

            if (systemDelta != 0)
            {
                return cpuDelta / (double)systemDelta;
            }
            else
            {
                return 0;
            }
        }

        private static double CalculateMemoryUsagePercentage(MemoryStats stats)
        {
            if (stats.Limit != 0)
            {
                return stats.Usage / (double)stats.Limit;
            }
            else if (stats.MaxUsage != 0)
            {
                return stats.Usage / (double)stats.MaxUsage;
            }
            else
            {
                return 0;
            }
        }

        #endregion Private Methods
    }
}