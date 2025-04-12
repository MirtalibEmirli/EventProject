using AutoMapper;
using EventProject.Application.Features.Commands.EventCommands.UpdateEvent;
using EventProject.Application.Features.Queries.EventQueries.GetTrending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
        srcMember != null &&
        (srcMember is not string str || !string.IsNullOrWhiteSpace(str)) &&
        (srcMember is not int i || i != 0) &&
        (srcMember is not float f || f != 0) &&
    (srcMember is not Guid g || g != Guid.Empty)));

            CreateMap<Event, GetTrendingEventsDto>();

        }
    }
}
