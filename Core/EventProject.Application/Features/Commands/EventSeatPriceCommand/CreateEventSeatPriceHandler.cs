using EventProject.Application.Abstractions.Service;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventSeatPriceCommand;

public class CreateEventSeatPriceHandler : IRequestHandler<CreateEventSeatPriceRequest, ResponseModel<Unit>>
{
    private readonly IEventReadRepository _eventReadRepository;
    private readonly IEventPricingService _eventPricingService;
    public CreateEventSeatPriceHandler(IEventReadRepository eventReadRepository, IEventPricingService eventPricingService)
    {
        _eventReadRepository = eventReadRepository;
        _eventPricingService = eventPricingService;
    }

    public async Task<ResponseModel<Unit>> Handle(CreateEventSeatPriceRequest request, CancellationToken cancellationToken)
    {
        var eventEntity = await _eventReadRepository.Table.Include(e => e.Location).FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken);


        if (eventEntity is null) return new ResponseModel<Unit>(new List<string> { "Event tapılmadı." });

        await _eventPricingService.AssiginPricesToSeatAsync(eventEntity);
        return new ResponseModel<Unit>
        {
            IsSuccess = true,
            Data = Unit.Value
        };
    }
}
