﻿using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Refit.HttpClientFactory.Extensions
{
    internal class RefitHttpClientFactory : IRefitHttpClientFactory
    {
        public RefitHttpClientFactory(IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
        {
            HttpClientFactory = httpClientFactory;
            ServiceProvider = serviceProvider;
        }

        private IHttpClientFactory HttpClientFactory { get; }

        private IServiceProvider ServiceProvider { get; }

        public T CreateClient<T>(string name)
        {
            var client = HttpClientFactory.CreateClient(name);
            return RestService.For(client, ServiceProvider.GetRequiredService<IRequestBuilder<T>>());
        }
    }
}