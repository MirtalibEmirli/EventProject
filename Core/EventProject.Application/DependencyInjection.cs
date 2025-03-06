using AutoMapper;
using EventProject.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EventProject.Application
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {

            ///aoutomapper injection
            var mapperConfig = new MapperConfiguration(mc =>
            {

                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

    }
}
