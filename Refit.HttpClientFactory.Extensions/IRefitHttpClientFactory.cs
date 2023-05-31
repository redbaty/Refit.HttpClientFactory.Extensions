namespace Refit.HttpClientFactory.Extensions
{
    public interface IRefitHttpClientFactory
    {
        T CreateClient<T>(string name);
    }
}