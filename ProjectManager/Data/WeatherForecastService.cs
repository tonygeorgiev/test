using ProjectManager.Core.Common.Contracts;

namespace ProjectManager.Data
{
    public class WeatherForecastService
    {
        private readonly IEngine _engine;

        public WeatherForecastService(IEngine engine)
        {
            _engine = engine;
        }
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<string> GetForecastAsync(string input)
        {
            return _engine.Start(input);
        }
    }
}