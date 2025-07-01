using EventProject.Application.Repositories;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.Refresh;
using EventProject.Application.Repositories.UserMediaFileRepo;
using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Application.Repositories.Users;
using EventProject.Application.Repositories.VenueMediaFiles;
using EventProject.Application.Repositories.Venues;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Comments;
using EventProject.Persistence.Repository.EventCategories;
using EventProject.Persistence.Repository.EventMediaFiles;
using EventProject.Persistence.Repository.Events;
using EventProject.Persistence.Repository.Generics;
using EventProject.Persistence.Repository.Refresh;
using EventProject.Persistence.Repository.UserMediaFileRepo;
using EventProject.Persistence.Repository.UserRwEvents;
using EventProject.Persistence.Repository.Users;
using EventProject.Persistence.Repository.VenueMediaFiles;
using EventProject.Persistence.Repository.Venues;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventProject.Persistence;

public static class RegistrationService
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddDbContext<AppDbContext>(opt =>
        opt.UseLazyLoadingProxies() 
        .UseSqlServer(config.GetConnectionString("DefaultConnection")));
        //services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
        //services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));

         services.AddScoped<IEventCategoryWriteRepository, EventCategoryWriteRepository>();
         services.AddScoped<IEventCategoryReadRepository, EventCategoryReadRepository>();
         services.AddScoped<IEventWriteRepository, EventWriteRepository>();
         services.AddScoped<IEventReadRepository, EventReadRepository>();
         services.AddScoped<IVenueWriteRepository, VenueWriteRepository>();
         services.AddScoped<IVenueReadRepository, VenueReadRepository>();
         services.AddScoped<IEventMediaFileReadRepository, EventMediaFileReadRepository>();
         services.AddScoped<IEventMediaFileWriteRepository, EventMediaFileWriteRepository>();
       
         services.AddScoped<IEventMediaFileWriteRepository, EventMediaFileWriteRepository>();
         services.AddScoped<IVenueMediaFileWriteRepository, VenueMediaFileWriteRepository>();
         services.AddScoped<IVenueMediaFileReadRepository, VenueMediaFileReadRepository>();
         services.AddScoped<IUserReadRepsoitory, UserReadRepository>();
         services.AddScoped<IUserWriteRepository, UserWriteRepository>();
         services.AddScoped<IUserRwEventsReadRepository, UserRwEventsReadRepository>();
         services.AddScoped<IUserRwEventsWriteRepository
 , UserRwEventsWriteRepository>();
         services.AddScoped<IRefreshTokenRead,RefreshTokenRead>();
         services.AddScoped<IRefreshTokenWrite, RefreshTokenWrite>();
         services.AddScoped<ICommentReadRepository, CommentReadRepository>();
         services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
         services.AddScoped<IUserMediaFileRead, UserMediaFileRead>();
         services.AddScoped<IUserMediaFileWrite, UserMediaFileWrite>();
       return services;
    }
}
