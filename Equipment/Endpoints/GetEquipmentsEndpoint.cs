using CoreAccess.Equipment.Mappers;
using CoreAccess.Equipment.Models;
using CoreAccess.Equipment.Responses;
using CoreAccess.Equipment.Services;

namespace CoreAccess.Equipment.Endpoints;

public sealed class GetEquipmentsEndpoint(IEquipmentRepository equipmentRepository) : EquipmentEndpointWithoutRequest<GetEquipmentsResponse, EquipmentMapper>
{
    private readonly IEquipmentRepository equipmentRepository = equipmentRepository;

    protected override void PostConfiguration()
    {
        Get("/api/equipment");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var requestState  = ProcessorState<EquipmentRequestState>();
        var equipments = await equipmentRepository.GetAllEquipmentAsync(requestState.ConnectionString, ct);
        var response = equipments.Select(Map.FromEntity);

        await SendOkAsync(new()
        {
            Equipment = response,
            TotalRecords = response.Count()
        }, ct);
    }
}