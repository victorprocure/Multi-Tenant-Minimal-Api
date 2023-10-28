namespace CoreAccess.DataEnvironment.Requests;

public interface IHasTenantRequest
{
    public Guid TenantId { get; set; }
    public string ConnectionString { get; set; }
}