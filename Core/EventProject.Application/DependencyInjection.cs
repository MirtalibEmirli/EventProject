using AutoMapper;
using EventProject.Application.AutoMapper;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Services;
using EventProject.Application.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {

            ///aoutomapper injection
            var mapperConfig = new MapperConfiguration(mc =>
            {

                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            var a =

            services.AddMediatR(Assembly.GetExecutingAssembly());   //bunu bilmirem menasi nedir niye asssemblye muraciet gedr yeqin mediatr a harda isleyeceyini deyir dusunurem afro



            //cloudinary services
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>());
            services.AddScoped<CloudinaryService>();
            return services;
        }

    }
}
