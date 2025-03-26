using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Repositories.VenueMediaFiles;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Enums;
using MediatR;

namespace EventProject.Application.Features.Commands.VenueMediaFile.UploadVenueMedia;

public class UploadVenueMediaHandler(IStorageService storageService, IVenueReadRepository venueRead, IVenueMediaFileWriteRepository venueMedia) : IRequestHandler<UploadVenueMediaRequest, ResponseModel<Unit>>
{
    private readonly IStorageService _storageService = storageService;
    private readonly IVenueReadRepository _venueReadRepo = venueRead;
    private readonly IVenueMediaFileWriteRepository _venueMediaFileRepo = venueMedia;

    public async Task<ResponseModel<Unit>> Handle(UploadVenueMediaRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> medias = await _storageService.UploadAsync("venue-medias", request.Medias);
        var venue = await _venueReadRepo.GetByIdAsync(request.VenueId);
        await _venueMediaFileRepo.AddRangeAsync(medias.Select(m => new Domain.Entities.VenueMediaFile
        {
            FileName = m.fileName,
            Path = m.pathOrContainerName,
            StorageType = Enum.Parse<StorageType>(_storageService.StorageName),
            VenueId = venue.Id,
            CreatedDate = DateTime.Now,

        }));
        await _venueMediaFileRepo.SaveChangesAsync();
        return new ResponseModel<Unit> { Data = Unit.Value, IsSuccess = true, Message = $"VenueMedias are added to {_storageService.StorageName} successfully" };
    }
}
