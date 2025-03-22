using CloudinaryDotNet.Actions;
using EventProject.Application.Abstractions.Service;
using EventProject.Application.Repositories.EventSeatPrices;
using EventProject.Application.Repositories.Seats;
using EventProject.Application.Repositories.SectionWeights;
using EventProject.Domain.Entities;
using EventProject.Persistence.Repository.SectionWeights;
using System.Linq;

namespace EventProject.Persistence.Services;

public class EventPricingService(ISeatReadRepository seatReadRepository, ISeatWriteRepository seatWriteRepository, ISectionWeightReadRepository sectionWeightReadRepository, IEventSeatPriceWriteRepository eventSeatPriceWriteRepository) : IEventPricingService
{
    
    private readonly ISeatReadRepository _seatReadRepository = seatReadRepository;
    private readonly ISeatWriteRepository _seatWriteRepository= seatWriteRepository;
    private readonly ISectionWeightReadRepository _sectionWeightRepository = sectionWeightReadRepository;
    private readonly IEventSeatPriceWriteRepository _eventSeatPriceWriteRepository= eventSeatPriceWriteRepository;

    public async Task AssiginPricesToSeatAsync(Event eventEntity)
    {
        var seats = _seatReadRepository.GetWhere(s => s.VenueId == eventEntity.Location.Id);

        if (!seats.Any()) return ;


        var sectionWeights= _sectionWeightRepository.GetWhere(e=>e.VenueId==eventEntity.Location.Id).ToDictionary(w=>w.SectionName,w=>w.Weight);

        var eventSeatPrices = new List<EventSeatPrice>();
        foreach (var seat in seats)
        {
            var sectionWeight = sectionWeights.TryGetValue(seat.Section, out var w) ? w : 0.0f;
            var rowNumber = seat.Row;
            double rowWeight = 1.0 - ((rowNumber - 1) / 10.0);

            double factor = (sectionWeight + rowWeight) / 2.0;
            var price = eventEntity.MinPrice + (float)((eventEntity.MaxPrice - eventEntity.MinPrice) * factor);

            eventSeatPrices.Add(new EventSeatPrice
            {
                EventId = eventEntity.Id,
                SeatId = seat.Id,
                Price = price
            });
            await _eventSeatPriceWriteRepository.AddRangeAsync(eventSeatPrices);
            await _eventSeatPriceWriteRepository.SaveChangesAsync();
        }


     
    }
}
