namespace ProjectManager.ConsoleClient.Configs
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public TimeSpan CacheDurationInSeconds
        {
            get
            {
                return TimeSpan.FromSeconds(30);
            }
        }

        public string LogFilePath
        {
            get
            {
                return Directory.GetCurrentDirectory();
            }
        }
    }
}
