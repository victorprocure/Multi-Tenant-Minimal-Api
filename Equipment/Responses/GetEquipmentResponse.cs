namespace CoreAccess.Equipment.Responses;

public sealed class GetEquipmentResponse
{
    public long EquipmentId { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
}