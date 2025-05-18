using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.VenueMediaFiles;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.VenueMediaFile.DeleteVenueMedia;

public record DeleteVenueMediaRequest(string FileName) : IRequest<ResponseModel<Unit>>;

public class DeleteVenueMediaFileHandler(IStorageService storageService, IVenueMediaFileReadRepository venueMediaFileRead, IVenueMediaFileWriteRepository venueMediaFileWrite) : IRequestHandler<DeleteVenueMediaRequest, ResponseModel<Unit>>
{
    public async Task<ResponseModel<Unit>> Handle(DeleteVenueMediaRequest request, CancellationToken cancellationToken)
    {
        var media = venueMediaFileRead
            .GetWhere(x => x.FileName == request.FileName && x.IsDeleted != true).FirstOrDefault();
        if (media == null)
        {
            throw new NotFoundException($"{request.FileName} databasede yoxdur");
        }

        var fileUrl = media.FileName;

        var containerName = media.Path.Split('/')[0];
        var fileName = media.Path.Split('/')[1];
      await storageService.DeleteAsync(containerName, fileName);
        await venueMediaFileWrite.SoftDeleteAsync(media.Id.ToString());


        await venueMediaFileWrite.SaveChangesAsync();

        return new ResponseModel<Unit>
        {
            IsSuccess = true,
            Message = "File deleted successfully"
        };

    }
}
