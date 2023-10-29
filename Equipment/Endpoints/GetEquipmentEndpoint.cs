using CoreAccess.DataEnvironment.Extensions;
using CoreAccess.Equipment.Mappers;
using CoreAccess.Equipment.Models;
using CoreAccess.Equipment.Requests;
using CoreAccess.Equipment.Responses;
using CoreAccess.Equipment.Services;
using FastEndpoints;

namespace CoreAccess.Equipment.Endpoints;

public sealed class GetEquipmentEndpoint(IEquipmentRepository equipmentRepository) : Endpoint<GetEquipmentRequest, GetEquipmentResponse, EquipmentMapper>
{
    private readonly IEquipmentRepository equipmentRepository = equipmentRepository;

    public override void Configure()
    {
        Get("/api/equipment/{equipmentId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEquipmentRequest req, CancellationToken ct)
    {
        var requestState = HttpContext.GetTenantState();
        var equipment = await equipmentRepository.GetEquipmentByIdAsync(req.EquipmentId, requestState.ConnectionString, ct);
        var response = Map.FromEntity(equipment);

        await SendOkAsync(response, ct);
    }
}