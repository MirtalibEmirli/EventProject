using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.EventQueries.GetEventsForSelect;

public record GetEventsForSelectQuery : IRequest<ResponseModel<List<GetEventsForSelectResponse>>> { }
public class GetEventsForSelectHandler : IRequestHandler<GetEventsForSelectQuery, ResponseModel<List<GetEventsForSelectResponse>>>
{

    private readonly IEventReadRepository _eventReadRepository;

    public GetEventsForSelectHandler(IEventReadRepository eventReadRepository)
    { _eventReadRepository = eventReadRepository; }

    public async Task<ResponseModel<List<GetEventsForSelectResponse>>> Handle(GetEventsForSelectQuery request, CancellationToken cancellationToken)
    {
        var events = _eventReadRepository.GetAll().Select(e => new GetEventsForSelectResponse
        {
            Id = e.Id,
            Name = e.Title,
        }).ToList();
         
        return new ResponseModel<List<GetEventsForSelectResponse>>
        {
            Data = events,
            IsSuccess = true,
            Message = "Events retrieved successfully"
        };
    }
}

public record GetEventsForSelectResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}