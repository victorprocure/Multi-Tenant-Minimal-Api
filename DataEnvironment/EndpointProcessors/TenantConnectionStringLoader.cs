using CoreAccess.DataEnvironment.Requests;
using CoreAccess.DataEnvironment.Services;
using FastEndpoints;
using FluentValidation.Results;

namespace CoreAccess.DataEnvironment.EndpointProcessors;
public class TenantConnectionStringLoader : IGlobalPreProcessor
{
    public async Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        if (req is not IHasTenantRequest tenantRequest)
        {
            return;
        }

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
        tenantRequest.ConnectionString = connectionString;
        tenantRequest.TenantId = headerTenantId;
    }
}
