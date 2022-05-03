namespace DockerEngineApiClient
{
    public class DockerContainerStats
    {

        #region Public Constructors

        public DockerContainerStats(DateTimeOffset timestamp, double cpuUsagePercentage, long memoryUsage, long memoryUsageLimit, double memoryUsagePercentage, long storageReadBytes, long storageWriteBytes, long networkReadBytes, long networkWriteBytes)
        {
            this.Timestamp = timestamp;
            this.CpuUsagePercentage = cpuUsagePercentage;
            this.MemoryUsage = memoryUsage;
            this.MemoryUsageLimit = memoryUsageLimit;
            this.MemoryUsagePercentage = memoryUsagePercentage;
            this.StorageReadBytes = storageReadBytes;
            this.StorageWriteBytes = storageWriteBytes;
            this.NetworkReadBytes = networkReadBytes;
            this.NetworkWriteBytes = networkWriteBytes;
        }

        #endregion Public Constructors

        #region Public Properties


        public double CpuUsagePercentage
        {
            get;
        }

        public long MemoryUsage
        {
            get;
        }

        public long MemoryUsageLimit
        {
            get;
        }

        public double MemoryUsagePercentage
        {
            get;
        }

        public long NetworkReadBytes
        {
            get;
        }

        public long NetworkWriteBytes
        {
            get;
        }

        public long StorageReadBytes
        {
            get;
        }

        public long StorageWriteBytes
        {
            get;
        }

        public DateTimeOffset Timestamp
        {
            get;
        }

        #endregion Public Properties

    }
}
