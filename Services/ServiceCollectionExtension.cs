using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;
using BlazorApp.Services.Implementations;
using BlazorApp.Services.Interfaces;


namespace BlazorApp.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCardServices(this IServiceCollection services)
        {
            var jitterer = new Random();
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3,    // exponential back-off plus some jitter
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                    + TimeSpan.FromMilliseconds(jitterer.Next(0, 100)));
            
            var noOp = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

            services.AddHttpClient<ICardService, CardService>().AddPolicyHandler(request =>
                request.Method == HttpMethod.Get ? retryPolicy : noOp);

            return services;
        }


    }
}
