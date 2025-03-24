using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Enums;
using MediatR;
namespace EventProject.Application.Features.Commands.EventImageFile.UploadEventImage;


public class UploadEventImageHandler(IStorageService storageService, IEventReadRepository eventReadRepository, IEventMediaFileWriteRepository fileWriteRepository) : IRequestHandler<UploadEventImageRequest, ResponseModel<Unit>>
{
    private readonly IStorageService _storageService = storageService;
    private readonly IEventReadRepository _eventReadRepository = eventReadRepository;
    private readonly IEventMediaFileWriteRepository _eventMediaFileWriteRepository = fileWriteRepository;

    public async Task<ResponseModel<Unit>> Handle(UploadEventImageRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathorContainerName)> images = await _storageService.UploadAsync("event-images", request.Images);

        var eventToImg = await _eventReadRepository.GetByIdAsync(request.EventId.ToString());

        await _eventMediaFileWriteRepository.AddRangeAsync(images.Select(x => new Domain.Entities.EventMediaFile
        {
            FileName = x.fileName,
            CreatedDate = DateTime.Now,
            EventId = eventToImg.Id,
            StorageType = Enum.Parse<StorageType>(_storageService.StorageName),
            Path = x.pathorContainerName,

        }));

        await _eventMediaFileWriteRepository.SaveChangesAsync();
        return new ResponseModel<Unit> { Data = Unit.Value, Message = "Photos are added with succesfully to azure", IsSuccess = true };
    }
}
