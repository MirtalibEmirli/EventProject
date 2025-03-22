//using EventProject.Application.Abstractions.Storage;
//using EventProject.Application.ResponseModels.Generics;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EventProject.Application.Features.Commands.EventImageFile.UploadEventImage;

//public class UploadEventImageRequest(IStorageService storageService):IRequest<ResponseModel<Unit>>
//{
//    public int EventId { get; set; }
//    public IFormFileCollection ? Images { get; set; }
//}
