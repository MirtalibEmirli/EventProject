using EventProject.Application.Abstractions.Service;
using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Abstractions.Storage.Azure;
using EventProject.Application.Abstractions.Storage.Local;
using EventProject.Application.Abstractions.Token;
using EventProject.Domain.Enums;
using EventProject.Infrastructure.Services;
using EventProject.Infrastructure.Services.Storage;
using EventProject.Infrastructure.Services.Storage.Azure;
using EventProject.Infrastructure.Services.Storage.Local;
using EventProject.Infrastructure.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventProject.Infrastructure;

public static class ServiceRegistration
{

    public static void AddInfrastructureService(this IServiceCollection services,IConfiguration configuration )
    {
        services.AddScoped<IStorageService,StorageService>();
        services.AddScoped<ITokenHandler,TokenHandler>();
        services.AddTransient<IMailService, MailService>();
        services.Configure<MailSettings>(
            configuration.GetSection("Mail"));
    }

    public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
    { 
        services.AddScoped<IStorage,T>();
    
    
    }
    public static void AddStorage(this IServiceCollection services,StorageType storageType)
    {
        var storage = storageType switch
        {
            StorageType.LocalStorage => services.AddScoped<ILocalStorage, LocalStorage>(),
            StorageType.AzureStorage => services.AddScoped<IAzureStorage, AzureStorage>(),
            _ => services.AddScoped<ILocalStorage, LocalStorage>()

        };
    }
}
