﻿using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Repositories.Events;

using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.EventCategories;
using EventProject.Persistence.Repository.Events;

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
       
		return services;
    }
}
