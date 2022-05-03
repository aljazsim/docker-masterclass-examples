namespace DockerEngineApiClient;

public interface IClock
{
    DateTimeOffset Now { get; }
}
