namespace Refit.HttpClientFactory.Extensions.Tests;

public interface IGitHubApi
{
    HttpClient Client { get; }
        
    [Get("/users/{user}")]
    Task<IApiResponse> GetUser(string user);
}