using Microsoft.Extensions.DependencyInjection;


namespace Logging.Graylogs
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddGraylogs(this IServiceCollection services)
        {
            services.AddTransient(typeof(ILogger<>), typeof(GraylogsLogger<>));
            services.AddTransient<ILogger, GraylogsLogger>();
            services.AddSingleton<ILoggerFactory, GraylogsLoggerFactory>();
            return services;
        }
    }
}