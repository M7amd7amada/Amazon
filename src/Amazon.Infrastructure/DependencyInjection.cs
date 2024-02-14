using Amazon.Infrastructure.Common.Middlewares;
using Amazon.Infrastructure.Common.Settings;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AppSettingsOptions>
            (configuration.GetSection(AppSettingsOptions.AppSettings));

        services.AddLogging();
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return services;
    }
}