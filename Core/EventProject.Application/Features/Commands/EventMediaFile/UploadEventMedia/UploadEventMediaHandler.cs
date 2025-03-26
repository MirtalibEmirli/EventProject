using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Enums;
using MediatR;
namespace EventProject.Application.Features.Commands.EventMediaFile.UploadEventMedia;


public class UploadEventMediaHandler(IStorageService storageService, IEventReadRepository eventReadRepository, IEventMediaFileWriteRepository fileWriteRepository) : IRequestHandler<UploadEventMediaRequest, ResponseModel<Unit>>
{
    private readonly IStorageService _storageService = storageService;
    private readonly IEventReadRepository _eventReadRepository = eventReadRepository;
    private readonly IEventMediaFileWriteRepository _eventMediaFileWriteRepository = fileWriteRepository;

    public async Task<ResponseModel<Unit>> Handle(UploadEventMediaRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathorContainerName)> medias = await _storageService.UploadAsync("event-images", request.Medias);

        var eventToImg = await _eventReadRepository.GetByIdAsync(request.EventId);

        await _eventMediaFileWriteRepository.AddRangeAsync(medias.Select(x => new Domain.Entities.EventMediaFile
        {
            FileName = x.fileName,
            CreatedDate = DateTime.Now,
            EventId = eventToImg.Id,
            StorageType = Enum.Parse<StorageType>(_storageService.StorageName),//burda errror olurdu
            //sebeb ise  public string StorageName { get => _storage.GetType().Name; } storageservicede bunu bele yazmaq idi AzureStorage adi ile yaranib enumda ise Azure idi
            Path = x.pathorContainerName,

        }));

        await _eventMediaFileWriteRepository.SaveChangesAsync();
        return new ResponseModel<Unit> { Data = Unit.Value, Message = $"EventMedias are added with succesfully to {_storageService.StorageName}", IsSuccess = true };
    }
}
