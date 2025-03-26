using Application.PipelineBehavior;
using AutoMapper;
using EventProject.Application.AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

   

            services.AddMediatR(Assembly.GetExecutingAssembly());
          
            //fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //pipelinebehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            return services;
        }

    }
}
