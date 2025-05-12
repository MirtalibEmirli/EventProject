using EventProject.Application.Features.Queries.EventQueries.GetEvents;
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

namespace EventProject.Application.Features.Queries.EventQueries.GetEventMediaFile;

public record GetEventMediaFilesQuery(string EventId) : IRequest<ResponseModel<GetEventMediaFileResponse>>;
public class GetEventMediaFileHandler : IRequestHandler<GetEventMediaFilesQuery, ResponseModel<GetEventMediaFileResponse>>
{
    private readonly IEventReadRepository _eventReadRepository;

    public GetEventMediaFileHandler(IEventReadRepository eventReadRepository)
    {
        _eventReadRepository = eventReadRepository;
    }

    public async Task<ResponseModel<GetEventMediaFileResponse>> Handle(GetEventMediaFilesQuery request, CancellationToken cancellationToken)
    {
        var _event = await _eventReadRepository.GetByIdAsync(request.EventId);
        var medaias = _event.MediaFiles.Where(m=>m.IsDeleted!=true).Select(m => m.FileName).ToList();

        var result = new GetEventMediaFileResponse()
        {
            MediaFiles = medaias
        };
        return new ResponseModel<GetEventMediaFileResponse>
        {
            IsSuccess = true,
            Message = "Media files retrieved successfully",
            Data = result
        };
    }




}
