using Application.PipelineBehavior;
using AutoMapper;
using EventProject.Application.Abstractions.Jobs;
using EventProject.Application.AutoMapper;
using EventProject.Application.Services.Jobs;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Reflection;

namespace EventProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services )
        {

            ///aoutomapper injection
            var mapperConfig = new MapperConfiguration(mc =>
            {

                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new EventProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddMediatR(Assembly.GetExecutingAssembly());
          
            //fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //pipelinebehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            //logger

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddNLog();
            });
            //recentlyviewedd
            services.AddScoped<IRecentlyViewedJob, RecentlyViewedJob>();
            services.AddScoped<ISendMailAllUsersJob, SendMmailAllUsersJob>();
            return services;
        }

    }
}
