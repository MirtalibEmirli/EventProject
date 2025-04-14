using AutoMapper;
using EventProject.Application.DTOs;
using EventProject.Application.Features.Commands.EventCommands.UpdateEvent;

namespace EventProject.Application.AutoMapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<UpdateEventRequest, Event>()
     .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
     .ForMember(dest => dest.Id, opt => opt.Ignore())
     .ForMember(dest => dest.Comments, opt => opt.Ignore())
     .ForMember(dest => dest.MediaFiles, opt => opt.Ignore())

     .ForMember(dest => dest.StartTime, opt =>
         opt.Condition((src, dest, srcMember) =>
             src.StartTime.HasValue && src.StartTime.Value != DateTime.MinValue))

     .ForMember(dest => dest.EndTime, opt =>
         opt.Condition((src, dest, srcMember) =>
             src.EndTime.HasValue && src.EndTime.Value != DateTime.MinValue))

     .ForMember(dest => dest.AgeLimit, opt =>
         opt.Condition(src => src.AgeLimit.HasValue && src.AgeLimit.Value != 0))

     .ForMember(dest => dest.MinPrice, opt =>
         opt.Condition(src => src.MinPrice != 0))

     .ForMember(dest => dest.MaxPrice, opt =>
         opt.Condition(src => src.MaxPrice != 0))


     .ForMember(dest => dest.Status, opt =>
         opt.Condition(src => src.Status.HasValue))


     .ForMember(dest => dest.CategoryId, opt =>
         opt.Condition(src => src.CategoryId.HasValue && src.CategoryId.Value != Guid.Empty))


     .ForMember(dest => dest.LocationId, opt =>
         opt.Condition(src => src.LocationId.HasValue && src.LocationId.Value != Guid.Empty))


     .ForMember(dest => dest.Title, opt =>
         opt.Condition(src => !string.IsNullOrWhiteSpace(src.Title)))


     .ForMember(dest => dest.Description, opt =>
         opt.Condition(src => !string.IsNullOrWhiteSpace(src.Description)))


     .ForMember(dest => dest.IsTrend, opt => opt.MapFrom(src => src.IsTrend));

      CreateMap<Event, GetTrendingEventsDto>();

        }
    }
}
