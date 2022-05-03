namespace DockerEngineApiClient;

public class DockerContainerStatsWriter
{
    private readonly string filePath;

    public DockerContainerStatsWriter(string filePath)
    {
        this.filePath = filePath;
    }

    public async Task Write(DockerContainerStats dockerContainerStats)
    {
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        if (!File.Exists(filePath))
        {
            await File.WriteAllLinesAsync(filePath, new[] { GetHeaderRow() });
        }

        await File.AppendAllLinesAsync(filePath, new[] { GetStatRow(dockerContainerStats) });
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