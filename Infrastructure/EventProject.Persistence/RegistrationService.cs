﻿using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.Venues;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.EventCategories;
using EventProject.Persistence.Repository.Events;
using EventProject.Persistence.Repository.Venues;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventProject.Persistence;

public static class RegistrationService
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddDbContext<AppDbContext>(opt =>   opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<IEventCategoryWriteRepository, EventCategoryWriteRepository > ();
		services.AddScoped<IEventCategoryReadRepository, EventCategoryReadRepository>();
        services.AddScoped<IEventWriteRepository, EventWriteRepository>();
        services.AddScoped<IVenueWriteRepository, VenueWriteRepository>();
        services.AddScoped<IVenueReadRepository, VenueReadRepository>();
        return services;
    }
}
