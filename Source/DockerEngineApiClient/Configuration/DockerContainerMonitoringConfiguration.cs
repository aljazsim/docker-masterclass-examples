namespace DockerEngineApiClient.Configuration;

public class DockerContainerMonitoringConfiguration
{
    #region Public Properties

    public Dictionary<string, string> Containers
    {
        get;
        set;
    }

    public DockerConfiguration Docker
    {
        get;
        set;
    }

    #endregion Public Properties
}