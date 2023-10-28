namespace CoreAccess.DataEnvironment.Services;

public interface ITenantResolver
{
    public ValueTask<string> GetConnectionStringAsync(Guid tenantId);
}