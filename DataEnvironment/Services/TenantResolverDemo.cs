
namespace CoreAccess.DataEnvironment.Services;

public class TenantResolverDemo : ITenantResolver
{
    public const string CanadaConnectionString = "Canada";
    public const string USAConnectionString = "USA";
    public const string UKConnectionString = "UK";
    public const string AUConnectionString = "AU";

    private static readonly Dictionary<Guid, string> tenantConnectionStrings = new()
    {
        {Guid.Parse("682e3205-c6b4-44ff-8ad1-5e4706ff4171"), CanadaConnectionString},
        {Guid.Parse("a1d1705e-36ac-4ff4-958d-bd55faa0720d"), USAConnectionString},
        {Guid.Parse("b457a0d6-3ce5-4f15-99cc-0fb35e166e9e"), UKConnectionString},
        {Guid.Parse("4f7ff208-64d3-4247-a327-ec5df7bed3fb"), AUConnectionString}
    };

    public ValueTask<string> GetConnectionStringAsync(Guid tenantId)
    {
        if (tenantConnectionStrings.TryGetValue(tenantId, out var connectionString))
        {
            return ValueTask.FromResult(connectionString);
        }

        throw new InvalidOperationException($"Tenant ID: `{tenantId}` not found");
    }
}
