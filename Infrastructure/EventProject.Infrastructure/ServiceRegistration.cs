﻿

using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Abstractions.Storage.Azure;
using EventProject.Application.Abstractions.Storage.Local;
using EventProject.Domain.Enums;

using EventProject.Infrastructure.Services.Storage;
using EventProject.Infrastructure.Services.Storage.Azure;
using EventProject.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace EventProject.Infrastructure;

public static class ServiceRegistration
{

    public static void AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<IStorageService,StorageService>();
    }

    public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
    { 
        services.AddScoped<IStorage,T>();
    
    
    }
    public static void AddStorage(this IServiceCollection services,StorageType storageType)
    {
        var storage = storageType switch
        {
            StorageType.Local => services.AddScoped<ILocalStorage, LocalStorage>(),
            StorageType.Azure => services.AddScoped<IAzureStorage, AzureStorage>(),
            _ => services.AddScoped<ILocalStorage, LocalStorage>()

        };
    }
}
