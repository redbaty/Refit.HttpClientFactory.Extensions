using Microsoft.Extensions.DependencyInjection;

namespace Refit.HttpClientFactory.Extensions.Tests;

public class TestFactoryFixture : IDisposable
{
    public ServiceProvider ServiceProvider { get; private set; }

    public TestFactoryFixture()
    {
        var services = new ServiceCollection();
        // Register the required dependencies here
        services.AddRefitHttpClientFactory();
        services.AddRefitClient<IGitHubApi>("github-staging")
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api-staging.github.com/"));
        services.AddRefitClient<IGitHubApi>("github-production")
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.github.com/"));
        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        ServiceProvider.Dispose();
    }
}