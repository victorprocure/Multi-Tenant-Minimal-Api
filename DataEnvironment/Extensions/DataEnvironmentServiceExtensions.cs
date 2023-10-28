using CoreAccess.DataEnvironment.Services;

namespace CoreAccess.DataEnvironment.Extensions;

internal static class DataEnvironmentServiceExtensions
{
    public static IServiceCollection AddDataEnvironment(this IServiceCollection services)
    {
        if (services.Any(sd => sd.ImplementationType == typeof(ITenantResolver)))
        {
            return services;
        }

        services.AddSingleton<ITenantResolver, TenantResolverDemo>();

        return services;
    }
}