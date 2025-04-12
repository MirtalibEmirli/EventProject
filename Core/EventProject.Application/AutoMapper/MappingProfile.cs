using AutoMapper;
using EventProject.Application.DTOs;
using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using EventProject.Application.Features.Commands.EventCommands.UpdateEvent;
using EventProject.Application.Features.Commands.UserCommands.Register;
using EventProject.Application.Features.Queries.VenueQueries.GetAllVenueQueries;
using EventProject.Application.Features.Queries.VenueQueries.GetByIdVenueQueries;
using EventProject.Domain.Entities;

namespace EventProject.Application.AutoMapper;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<Category, CreateEventCategoryRequest>().ReverseMap();

        CreateMap<CreateEventCategoryResponse, Category>().ReverseMap().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id.ToString()));
        CreateMap<RegisterRequest, User>();

        //CreateMap<CreateEventRequest, Event>();
        CreateMap<GetAllCategories, Category>().ReverseMap();
        CreateMap<Venue, GetAllVenueResponse>();
        CreateMap<Venue, GetByIdVenueResponse>();


    }
}
