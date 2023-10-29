using CoreAccess.Equipment.Processors;
using FastEndpoints;

namespace CoreAccess.Equipment.Endpoints;

public abstract class EquipmentEndpoint<TRequest> : Endpoint<TRequest> where TRequest : notnull
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<TRequest>());
        PostConfiguration();
    }

    protected abstract void PostConfiguration();
}

public abstract class EquipmentEndpoint<TRequest, TResponse, TMapper> : Endpoint<TRequest, TResponse, TMapper> where TRequest : notnull where TResponse : notnull where TMapper : notnull, IMapper
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<TRequest>());
        PostConfiguration();
    }
    protected abstract void PostConfiguration();
}

public abstract class EquipmentEndpointWithMapper<TRequest, TMapper> : EndpointWithMapper<TRequest, TMapper> where TRequest : notnull where TMapper : notnull, IRequestMapper
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<TRequest>());
        PostConfiguration();
    }
    protected abstract void PostConfiguration();
}

public abstract class EquipmentEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse> where TRequest : notnull where TResponse : notnull
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<TRequest>());
        PostConfiguration();
    }
    protected abstract void PostConfiguration();
}

public abstract class EquipmentEndpointWithoutRequest : EndpointWithoutRequest
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<EmptyRequest>());
        PostConfiguration();
    }
    protected abstract void PostConfiguration();
}

public abstract class EquipmentEndpointWithoutRequest<TResponse> : EndpointWithoutRequest<TResponse> where TResponse : notnull
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<EmptyRequest>());
        PostConfiguration();
    }
    protected abstract void PostConfiguration();
}

public abstract class EquipmentEndpointWithoutRequest<TResponse, TMapper> : EndpointWithoutRequest<TResponse, TMapper> where TResponse : notnull where TMapper : notnull, IResponseMapper
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<EmptyRequest>());
        PostConfiguration();
    }
    protected abstract void PostConfiguration();
}

public abstract class EquipmentEndpointWithMapping<TRequest, TResponse, TEntity> : EndpointWithMapping<TRequest, TResponse, TEntity> where TRequest : notnull
{
    public override void Configure()
    {
        PreProcessors(new TenantConnectionStringLoader<TRequest>());
        PostConfiguration();
    }
    protected abstract void PostConfiguration();
}