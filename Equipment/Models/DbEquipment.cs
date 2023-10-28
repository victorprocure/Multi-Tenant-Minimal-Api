namespace CoreAccess.Equipment.Models;
public sealed record DbEquipment
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
}