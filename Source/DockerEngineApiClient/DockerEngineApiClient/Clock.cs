namespace DockerEngineApiClient;

public class Clock : IClock
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}