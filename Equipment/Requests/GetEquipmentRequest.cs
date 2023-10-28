using CoreAccess.DataEnvironment.Requests;

namespace CoreAccess.Equipment.Requests;
public sealed class GetEquipmentRequest : IHasTenantRequest
{
    public Guid TenantId { get; set; }
    public string ConnectionString { get; set; } = default!;

    public long EquipmentId { get; set; }
}