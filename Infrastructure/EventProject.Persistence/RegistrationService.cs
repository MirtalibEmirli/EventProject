using EventProject.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventProject.Persistence;

public static class RegistrationService
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddDbContext<AppDbContext>(opt =>   opt.UseSqlServer(config.GetConnectionString("Default")));
        return services;
    }
}
