using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventProject.Application.Features.Commands.EventMediaFile.UploadEventMedia;

public class UploadEventMediaRequest() : IRequest<ResponseModel<Unit>>
{
    public string EventId { get; set; }
    public IFormFileCollection? Medias { get; set; }
}
