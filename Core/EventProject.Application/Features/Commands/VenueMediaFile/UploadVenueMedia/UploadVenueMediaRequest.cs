using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.VenueMediaFile.UploadVenueMedia;

public class UploadVenueMediaRequest:IRequest<ResponseModel<Unit>>
{
    public required string VenueId { get; set; }
    public IFormFileCollection? Medias { get; set; }
}
