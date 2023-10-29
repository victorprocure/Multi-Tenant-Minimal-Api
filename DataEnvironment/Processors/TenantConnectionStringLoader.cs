using CoreAccess.DataEnvironment.Models;
using CoreAccess.DataEnvironment.Services;
using FastEndpoints;
using FluentValidation.Results;

namespace CoreAccess.DataEnvironment.Processors;
public class TenantConnectionStringLoader : IGlobalPreProcessor
{
    public const string TenantConnectionStringKey = "tenant-connection-string";

    public async Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        if (!ctx.Request.Headers.TryGetValue("x-tenant-id", out var tenantId))
        {
            return;
        }

        if (!Guid.TryParse(tenantId, out var headerTenantId))
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

        var state = new TenantConnectionStringState(headerTenantId, connectionString);
        if (ctx.Items.TryGetValue(TenantConnectionStringKey, out var _))
        {
            ctx.Items.Remove(TenantConnectionStringKey);
        }

        ctx.Items.Add(TenantConnectionStringKey, state);
    }
}
