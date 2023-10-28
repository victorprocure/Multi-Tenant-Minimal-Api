using CoreAccess.DataEnvironment.Services;
using CoreAccess.Equipment.Models;

namespace CoreAccess.Equipment.Services;

public sealed class EquipmentRepositoryDemo : IEquipmentRepository
{
    public ValueTask<IEnumerable<DbEquipment>> GetAllEquipmentAsync(string connectionString, CancellationToken cancellationToken)
    {
        var connectionStringName = connectionString switch
        {
            TenantResolverDemo.CanadaConnectionString => "CA",
            TenantResolverDemo.USAConnectionString => "US",
            TenantResolverDemo.UKConnectionString => "UK",
            TenantResolverDemo.AUConnectionString => "AU",
            _ => throw new InvalidOperationException("Location not found")
        };

        var equipments = Enumerable.Range(1, 10).Select(id => new DbEquipment
        {
            Id = id,
            Name = $"{connectionStringName} Test Equipment",
            Type = "Testing"
        });

        return ValueTask.FromResult(equipments);
    }

    public ValueTask<DbEquipment> GetEquipmentByIdAsync(long equipmentId, string connectionString, CancellationToken cancellationToken)
    {
        var connectionStringName = connectionString switch
        {
            TenantResolverDemo.CanadaConnectionString => "CA",
            TenantResolverDemo.USAConnectionString => "US",
            TenantResolverDemo.UKConnectionString => "UK",
            TenantResolverDemo.AUConnectionString => "AU",
            _ => throw new InvalidOperationException("Location not found")
        };

        var equipment = new DbEquipment
        {
            Id = equipmentId,
            Name = $"{connectionStringName} Test Equipment",
            Type = "Test"
        };

        return ValueTask.FromResult(equipment);
    }
}