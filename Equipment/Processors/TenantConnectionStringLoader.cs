using CoreAccess.DataEnvironment.Services;
using CoreAccess.Equipment.Models;
using FastEndpoints;
using FluentValidation.Results;

namespace CoreAccess.Equipment.Processors;
public class TenantConnectionStringLoader<TRequest> : PreProcessor<TRequest, EquipmentRequestState>
{
    public override async Task PreProcessAsync(TRequest req, EquipmentRequestState equipmentRequestState, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        if (!Guid.TryParse(ctx.Request.Headers["x-tenant-id"], out var headerTenantId))
        {
            failures.Add(new("TenantId", "Tenant Id supplied is invalid"));
            if (!ctx.ResponseStarted())
            {
                await ctx.Response.SendErrorsAsync(failures, cancellation: ct);
            }

            return;
        }

        var tenantResolver = ctx.Resolve<ITenantResolver>();
        var connectionString = await tenantResolver.GetConnectionStringAsync(headerTenantId);
        equipmentRequestState.ConnectionString = connectionString;
    }
}
