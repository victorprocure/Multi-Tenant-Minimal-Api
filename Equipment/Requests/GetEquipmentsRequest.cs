using CoreAccess.DataEnvironment.Requests;

namespace CoreAccess.Equipment.Requests;

public sealed class GetEquipmentsRequest : IHasTenantRequest
{
    public Guid TenantId { get; set; }
    public string ConnectionString { get; set; } = default!;
}