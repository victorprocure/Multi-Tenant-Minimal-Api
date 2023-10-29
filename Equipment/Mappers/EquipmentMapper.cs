using CoreAccess.Equipment.Models;
using CoreAccess.Equipment.Requests;
using CoreAccess.Equipment.Responses;
using FastEndpoints;

namespace CoreAccess.Equipment.Mappers;

public sealed class EquipmentMapper : ResponseMapper<GetEquipmentResponse, DbEquipment>
{
    public override GetEquipmentResponse FromEntity(DbEquipment e)
        => new()
        {
            EquipmentId = e.Id,
            Name = e.Name,
            Type = e.Type
        };
}