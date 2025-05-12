using Application.PipelineBehavior;
using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Abstractions.Storage.Azure;
using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventProject.Application.Features.Commands.EventMediaFile.DeleteEventMedia;


public record DeleteEventMediaRequest(string FileName) : IRequest<ResponseModel<Unit>>;


public class DeleteEventMediaHandler(IStorageService storageService, IEventMediaFileReadRepository eventMediaReadRepository, IEventMediaFileWriteRepository fileWriteRepository) : IRequestHandler<DeleteEventMediaRequest, ResponseModel<Unit>>
{
    private readonly IStorageService _storageService = storageService;
    private readonly IEventMediaFileReadRepository _eventMediaFileReadRepository = eventMediaReadRepository;

    private readonly IEventMediaFileWriteRepository _eventMediaFileWriteRepository = fileWriteRepository;

    public async Task<ResponseModel<Unit>> Handle(DeleteEventMediaRequest request, CancellationToken cancellationToken)
    {
        var file = _eventMediaFileReadRepository.GetWhere(x => x.FileName == request.FileName && x.IsDeleted != true).FirstOrDefault();
        if (file == null)
        {
            return new ResponseModel<Unit> { IsSuccess = false, Message = "File not found" };
        }
        var fileUrl = file.FileName;
        var containerName = file.Path.Split('/')[0];
        var fileName = file.Path.Split('/')[1];
       
         await _storageService.DeleteAsync(containerName, fileName);
        await _eventMediaFileWriteRepository.SoftDeleteAsyncByName(fileUrl);

        return new ResponseModel<Unit> { IsSuccess = true, Message = "File deleted successfully" };
    }
}



