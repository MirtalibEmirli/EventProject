using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCommands.CreateEvent;

public class CreateEventHandler : IRequestHandler<CreateEventRequest, ResponseModel<Guid>>
{
    private readonly IEventWriteRepository _eventWriteRepository;
    private readonly IEventCategoryReadRepository _eventCategoryReadRepository;
    private readonly IVenueReadRepository _venueReadRepository;

    public CreateEventHandler(IEventCategoryReadRepository eventCategoryReadRepository, IVenueReadRepository venueReadRepository, IEventWriteRepository eventWriteRepository)
    {
        _eventCategoryReadRepository = eventCategoryReadRepository;
        _venueReadRepository = venueReadRepository;
        _eventWriteRepository = eventWriteRepository;
    }

    public async Task<ResponseModel<Guid>> Handle(CreateEventRequest request, CancellationToken cancellationToken)
    {


        var categoryExists = await _eventCategoryReadRepository.GetByIdAsync(request.CategoryId.ToString());
        var locationExists= await _venueReadRepository.GetByIdAsync(request.LocationId.ToString());
        if (categoryExists is null) return new ResponseModel<Guid>(new List<string> {"Category tapilmir" });
        if (categoryExists is null) return new ResponseModel<Guid>(new List<string> { "Venue tapilmir" });

        var newEvent = new Event
        {
            Title = request.Title,
            Description = request.Description,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            AgeLimit = request.AgeLimit,
            LocationId = request.LocationId,
            MinPrice = request.MinPrice,
            MaxPrice = request.MaxPrice,
            Status = request.Status,
            CategoryId = request.CategoryId,
            CreatedDate = DateTime.Now
            
        };

       await _eventWriteRepository.AddAsync(newEvent);
        await _eventWriteRepository.SaveChangesAsync();


        return new ResponseModel<Guid> {  IsSuccess =true,Data = newEvent.Id};

    }
}
