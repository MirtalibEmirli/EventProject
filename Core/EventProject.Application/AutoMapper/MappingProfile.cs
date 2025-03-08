using AutoMapper;
using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using EventProject.Domain.Entities;

namespace EventProject.Application.AutoMapper;

public class MappingProfile:Profile
{

    public MappingProfile()
    {
        CreateMap<EventCategory,CreateEventCategoryRequest>().ReverseMap();
        CreateMap<CreateEventCategoryResponse,EventCategory>().ReverseMap().ForMember(dest=>dest.CategoryId,opt=>opt.MapFrom(src=>src.Id.ToString()));    
    }
}
