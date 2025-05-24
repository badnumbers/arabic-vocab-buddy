namespace ArabicVocabBuddy.Client
{
    public interface IEnvironmentManager
    {
        string ApiBaseUrl { get; }

        string EnvironmentName { get; }
    }
}