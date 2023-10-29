using CoreAccess.DataEnvironment.Models;
using CoreAccess.DataEnvironment.Processors;

namespace CoreAccess.DataEnvironment.Extensions;

public static class DataEnvironmentHttpExtensions
{
    public static TenantConnectionStringState GetTenantState(this HttpContext httpContext)
    {
        if (httpContext.Items.TryGetValue(TenantConnectionStringLoader.TenantConnectionStringKey, out var state)
            && state is TenantConnectionStringState connectionStringState)
        {
            return connectionStringState;
        }

        throw new InvalidOperationException("Tenant connection string state was not loaded");
    }
}