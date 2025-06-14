using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Abstractions.Storage;
using EventProject.Application.Repositories.UserMediaFileRepo;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserMedia;

public class UploadUserMediaRequest : IRequest<ResponseModel<Unit
    >> { public IFormFileCollection? Media { get; set; } };


public class UploadUserMediaHandler(
    ICurrentUserService currentUserService,
    IUserMediaFileRead userMediaFileRead,
    IUserMediaFileWrite userMediaFileWrite,
    IStorageService storageService
) : IRequestHandler<UploadUserMediaRequest, ResponseModel<Unit>>
{
    private readonly ICurrentUserService _currentUserService = currentUserService;
    private readonly IUserMediaFileRead _readRepo = userMediaFileRead;
    private readonly IUserMediaFileWrite _writeRepo = userMediaFileWrite;
    private readonly IStorageService _storageService = storageService;

    public async Task<ResponseModel<Unit>> Handle(UploadUserMediaRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();

        if (request.Media == null)
        {
            return new ResponseModel<Unit> {  
            IsSuccess=false,Message="Şəkil yüükləyin!"} ;
        }

        // Əvvəlki şəkli tap
        var existingMedia =   _readRepo.GetWhere(u=>u.UserId==userId).FirstOrDefault();

        if (existingMedia != null)
        {
            await _writeRepo.SoftDeleteAsync(existingMedia.Id.ToString()
                );
        }

        // Şəkli yüklə
        var uploadResult = await _storageService.UploadAsync("user-profile-media",       request.Media  );

        var mediaData = uploadResult.First();

        var newMedia = new UserMediaFile
        {
            UserId = userId,
            FileName = mediaData.fileName,
            Path = mediaData.pathOrContainer,
            StorageType = Enum.Parse<StorageType>(_storageService.StorageName),
            CreatedDate = DateTime.UtcNow
        };

        await _writeRepo.AddAsync(newMedia);
        await _writeRepo.SaveChangesAsync();

        return new ResponseModel<Unit>
        {
            IsSuccess = true,
            Message = "Profil şəkli uğurla yeniləndi."
        };
    }
}
