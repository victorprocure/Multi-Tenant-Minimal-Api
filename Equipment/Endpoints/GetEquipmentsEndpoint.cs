using CoreAccess.Equipment.Mappers;
using CoreAccess.Equipment.Requests;
using CoreAccess.Equipment.Responses;
using CoreAccess.Equipment.Services;
using FastEndpoints;

namespace CoreAccess.Equipment.Endpoints;

public sealed class GetEquipmentsEndpoint(IEquipmentRepository equipmentRepository) : Endpoint<GetEquipmentsRequest, GetEquipmentsResponse, EquipmentMapper>
{
    private readonly IEquipmentRepository equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Get("/api/equipment");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEquipmentsRequest req, CancellationToken ct)
    {
        var equipments = await equipmentRepository.GetAllEquipmentAsync(req.ConnectionString, ct);
        var response = equipments.Select(Map.FromEntity);

        await SendOkAsync(new()
        {
            Equipment = response,
            TotalRecords = response.Count()
        }, ct);
    }
}