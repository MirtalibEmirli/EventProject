using AutoMapper;
using CloudinaryDotNet;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.Medias;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Application.Services.CloudinaryServices;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Features.Commands.EventCommands.CreateEvent;

public class CreateEventHandler(IEventWriteRepository eventWrite, IMapper mapper, IEventCategoryReadRepository eventCategoryRead, CloudinaryService cloudinaryService, IMediaRepository mediaRepository) : IRequestHandler<CreateEventRequest, ResponseModel<CreateEventResponse>>
{
    private readonly CloudinaryService _cloudinaryService = cloudinaryService;
    private readonly IEventWriteRepository eventWriteRepository = eventWrite;
    private readonly IMapper _mapper = mapper;
    public async Task<ResponseModel<CreateEventResponse>> Handle(CreateEventRequest request, CancellationToken cancellationToken)
    {

        var categories = await eventCategoryRead.GetAllAsync();

        var selectedCategory = categories.FirstOrDefault(c => c.CategoryName == request.CategoryName);
        if (selectedCategory == null)
            throw new BadRequestException($"There is no category with {selectedCategory?.CategoryName} in database");



        var eventEntity = _mapper.Map<Event>(request);

        eventEntity.CategoryId = selectedCategory.Id;

        await eventWriteRepository.AddAsync(eventEntity);


        await eventWriteRepository.SaveChangesAsync();





        foreach (var media in request.Medias)
        {

            var extension = Path.GetExtension(media.FileName).ToLowerInvariant();
            var url = string.Empty;
            if (extension == ".img"||extension==".png" || extension == ".jpg" || extension == ".jpeg")
            {
                url = await _cloudinaryService.UploadImageAsync(media);

            }

            else if (extension is ".mp4" || extension == ".avi")
            {
                url = await _cloudinaryService.UploadVideoAsync(media);
            }
            if (string.IsNullOrEmpty(url))
                continue;

            var mediaToDb = new Media
            {
                Url = url,
                EventId = eventEntity.Id,
                MediaType = extension,
            };
            await mediaRepository.AddAsync(mediaToDb);
        }
        await mediaRepository.SaveAsync();



        return new ResponseModel<CreateEventResponse>
        {
            Data = new CreateEventResponse
            {
                EventId = eventEntity.Id.ToString()

            },
            IsSuccess = true
            ,
            Message = "Event created successfully with media files."
        };

    }


}
