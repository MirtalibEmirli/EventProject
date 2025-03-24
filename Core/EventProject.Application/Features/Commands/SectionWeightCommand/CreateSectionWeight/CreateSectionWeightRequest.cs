

using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventProject.Application.Features.Commands.SectionWeightCommand.CreateSectionWeight;

public class CreateSectionWeightRequest : IRequest<ResponseModel<Unit>>
{
    public Guid VenueId { get; set; }
    public IFormFile File { get; set; } = null!;
}