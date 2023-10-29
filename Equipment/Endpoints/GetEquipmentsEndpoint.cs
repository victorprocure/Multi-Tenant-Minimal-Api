using CoreAccess.DataEnvironment.Extensions;
using CoreAccess.Equipment.Mappers;
using CoreAccess.Equipment.Responses;
using CoreAccess.Equipment.Services;
using FastEndpoints;

namespace CoreAccess.Equipment.Endpoints;

public sealed class GetEquipmentsEndpoint(IEquipmentRepository equipmentRepository) : EndpointWithoutRequest<GetEquipmentsResponse, EquipmentMapper>
{
    private readonly IEquipmentRepository equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Get("/api/equipment");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var requestState = HttpContext.GetTenantState();
        var equipments = await equipmentRepository.GetAllEquipmentAsync(requestState.ConnectionString, ct);
        var response = equipments.Select(Map.FromEntity);

        await SendOkAsync(new()
        {
            Equipment = response,
            TotalRecords = response.Count()
        }, ct);
    }
}