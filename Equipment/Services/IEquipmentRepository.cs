using CoreAccess.Equipment.Models;

namespace CoreAccess.Equipment.Services;

public interface IEquipmentRepository
{
    ValueTask<DbEquipment> GetEquipmentByIdAsync(long equipmentId, string connectionString, CancellationToken cancellationToken);

    ValueTask<IEnumerable<DbEquipment>> GetAllEquipmentAsync(string connectionString, CancellationToken cancellationToken);
}