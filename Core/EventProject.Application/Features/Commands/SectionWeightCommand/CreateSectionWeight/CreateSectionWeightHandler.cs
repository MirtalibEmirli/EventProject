

using EventProject.Application.Repositories.SectionWeights;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace EventProject.Application.Features.Commands.SectionWeightCommand.CreateSectionWeight;

public class CreateSectionWeightHandler : IRequestHandler<CreateSectionWeightRequest, ResponseModel<Unit>>
{
    private readonly ISectionWeightWriteRepository _sectionWeightWriteRepository;

    public CreateSectionWeightHandler(ISectionWeightWriteRepository sectionWeightWriteRepository)
    {
        _sectionWeightWriteRepository = sectionWeightWriteRepository;
    }

    public async Task<ResponseModel<Unit>> Handle(CreateSectionWeightRequest request, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(request.File.OpenReadStream(), Encoding.UTF8);
        var json = await reader.ReadToEndAsync(cancellationToken);

        var sectionWeights = JsonConvert.DeserializeObject<List<SectionWeight>>(json);

        if (sectionWeights == null || !sectionWeights.Any())
        {
            return new ResponseModel<Unit>(new List<string> { "JSON faylı boşdur və ya format yanlışdır." });
        }

        foreach (var sw in sectionWeights)
        {
            sw.VenueId = request.VenueId;
        }

        await _sectionWeightWriteRepository.AddRangeAsync(sectionWeights);
        await _sectionWeightWriteRepository.SaveChangesAsync();
        return new ResponseModel<Unit>
        {
            IsSuccess = true,
            Data = Unit.Value
        };
    }
}
