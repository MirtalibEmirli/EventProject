using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.SectionPriceRepo;
using EventProject.Application.Repositories.SectionRepo;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCommands.CreateSection
{
    public class CreateSectionRequest : IRequest<ResponseModel<Unit>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid EventId { get; set; }
    }

    public class CreateSectionHandler : IRequestHandler<CreateSectionRequest, ResponseModel<Unit>>
    {
        private readonly IEventReadRepository _eventReadRepository;
        private readonly ISectionWriteRepository _sectionWriteRepository;
        private readonly ISectionPriceWriteRepository _sectionPriceWriteRepository;

        public CreateSectionHandler(
            IEventReadRepository eventReadRepository,
            ISectionWriteRepository sectionWriteRepository,
            ISectionPriceWriteRepository sectionPriceWriteRepository)
        {
            _eventReadRepository = eventReadRepository;
            _sectionWriteRepository = sectionWriteRepository;
            _sectionPriceWriteRepository = sectionPriceWriteRepository;
        }

        public async Task<ResponseModel<Unit>> Handle(CreateSectionRequest request, CancellationToken cancellationToken)
        {
       
            var eventEntity = await _eventReadRepository.GetByIdAsync(request.EventId.ToString());
            if (eventEntity == null)
            {
                throw new BadRequestException("Bu event mövcud deyil.");
            }

          
            var newSection = new Section
            {
                Name = request.Name,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

          
            await _sectionWriteRepository.AddAsync(newSection);
            await _sectionWriteRepository.SaveChangesAsync();

             
            var newSectionPrice = new SectionPrice
            {
                Price = request.Price,
                EventId = request.EventId,
                SectionId = newSection.Id
            };

          
            await _sectionPriceWriteRepository.AddAsync(newSectionPrice);
            await _sectionPriceWriteRepository.SaveChangesAsync();

      
            return new ResponseModel<Unit>
            {
                IsSuccess = true,
                Message = $"Section '{newSection.Name}' yaradıldı və qiymət verildi."
            };
        }
    }
}
