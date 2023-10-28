namespace CoreAccess.Equipment.Responses;
public sealed class GetEquipmentsResponse
{
    public int TotalRecords { get; set; }
    public IEnumerable<GetEquipmentResponse> Equipment { get; set; } = Enumerable.Empty<GetEquipmentResponse>();
}