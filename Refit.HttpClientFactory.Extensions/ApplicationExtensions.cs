using Microsoft.Extensions.DependencyInjection;

namespace Refit.HttpClientFactory.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddRefitHttpClientFactory(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IRefitHttpClientFactory, RefitHttpClientFactory>();
        }

        public static IHttpClientBuilder AddRefitClient<T>(this IServiceCollection services, string name) where T : class
        {
            services.AddRefitHttpClientFactory();
            services.AddRefitClient<T>();
            return services
                .AddHttpClient(name)
                .AddTypedClient((client, serviceProvider) => RestService.For(client, serviceProvider.GetService<IRequestBuilder<T>>()!));
        }
    }
}