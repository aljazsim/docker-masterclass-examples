namespace DockerEngineApiClient;

public class DockerContainerStatsWriter : IDisposable
{
    private FileStream fileStream;
    private StreamWriter fileWriter;

    public DockerContainerStatsWriter(string filePath)
    {
        this.fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
        this.fileWriter = new StreamWriter(fileStream);
    }

    public void Dispose()
    {
        this.fileWriter?.Dispose();
        this.fileWriter = null;

        this.fileStream?.Dispose();
        this.fileStream = null;
    }

    public async Task Write(DockerContainerStats dockerContainerStats)
    {
        if (this.fileStream != null)
        {
            if (this.fileStream.Position == 0)
            {
                await this.fileWriter.WriteLineAsync(GetHeaderRow());
            }

            await this.fileWriter.WriteLineAsync(GetStatRow(dockerContainerStats));
        }
    }

    private string GetHeaderRow()
    {
        var columns = new[] {
            nameof(DockerContainerStats.Timestamp),
            nameof(DockerContainerStats.CpuUsagePercentage),
            nameof(DockerContainerStats.MemoryUsage),
            nameof(DockerContainerStats.MemoryUsageLimit),
            nameof(DockerContainerStats.MemoryUsagePercentage),
            nameof(DockerContainerStats.StorageReadBytes),
            nameof(DockerContainerStats.StorageWriteBytes),
            nameof(DockerContainerStats.NetworkReadBytes),
            nameof(DockerContainerStats.NetworkWriteBytes),
        };

        return string.Join(",", columns.Select(c => $"\"{c}\"").ToArray());
    }

    private string GetStatRow(DockerContainerStats dockerContainerStats)
    {
        var columns = new string[] {
            dockerContainerStats.Timestamp.ToString(),
            dockerContainerStats.CpuUsagePercentage.ToString(),
            dockerContainerStats.MemoryUsage.ToString(),
            dockerContainerStats.MemoryUsageLimit.ToString(),
            dockerContainerStats.MemoryUsagePercentage.ToString(),
            dockerContainerStats.StorageReadBytes.ToString(),
            dockerContainerStats.StorageWriteBytes.ToString(),
            dockerContainerStats.NetworkReadBytes.ToString(),
            dockerContainerStats.NetworkWriteBytes.ToString(),
        };

        return string.Join(",", columns.Select(c => $"\"{c}\"").ToArray());
    }
}
