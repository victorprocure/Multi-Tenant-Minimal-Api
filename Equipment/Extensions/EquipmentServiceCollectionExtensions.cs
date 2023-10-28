using System.Security.Cryptography.X509Certificates;
using CoreAccess.Equipment.Services;

namespace CoreAccess.Equipment.Extensions;

public static class EquipmentServiceCollectionExtensions
{
    public static IServiceCollection AddEquipment(this IServiceCollection services)
    {
        if (services.Any(sd => sd.ImplementationType == typeof(IEquipmentRepository)))
        {
            return services;
        }

        services.AddSingleton<IEquipmentRepository, EquipmentRepositoryDemo>();

        return services;
    }
}