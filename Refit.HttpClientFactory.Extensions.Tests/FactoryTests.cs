using Microsoft.Extensions.DependencyInjection;

namespace Refit.HttpClientFactory.Extensions.Tests
{
    public class FactoryTests : IClassFixture<TestFactoryFixture>
    {
        private readonly TestFactoryFixture _factoryFixture;

        public FactoryTests(TestFactoryFixture factoryFixture)
        {
            _factoryFixture = factoryFixture;
        }

        [Fact]
        public void TestRefitFactoryNotNull()
        {
            var httpClientFactory = _factoryFixture.ServiceProvider.GetService<IRefitHttpClientFactory>();
            Assert.NotNull(httpClientFactory);
        }

        [Fact]
        public void TestMultipleEnvironments()
        {
            var httpClientFactory = _factoryFixture.ServiceProvider.GetRequiredService<IRefitHttpClientFactory>();
            var stagingApi = httpClientFactory.CreateClient<IGitHubApi>("github-staging");
            var productionApi = httpClientFactory.CreateClient<IGitHubApi>("github-production");

            Assert.NotNull(stagingApi);
            Assert.NotNull(productionApi);
            
            Assert.Equal("https://api.github.com/", productionApi.Client.BaseAddress!.ToString());
            Assert.Equal("https://api-staging.github.com/", stagingApi.Client.BaseAddress!.ToString());
        }
    }
}