namespace ArabicVocabBuddy.Client
{
    public class EnvironmentManager : IEnvironmentManager
    {
        private readonly IConfiguration _configuration;

        public EnvironmentManager(IConfiguration configuration, string environmentName)
        {
            _configuration = configuration;
            EnvironmentName = environmentName;
        }
        
        public string ApiBaseUrl => _configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("ApiBaseUrl is not configured.");

        public string EnvironmentName { get; init; }
    }
}