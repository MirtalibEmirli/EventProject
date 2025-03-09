using AutoMapper;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory
{
    public class CreateEventCategoryHandler(IEventCategoryWriteRepository eventCategoryWrite, IMapper mapper) : IRequestHandler<CreateEventCategoryRequest, ResponseModel<CreateEventCategoryResponse>>
    {
        private readonly IEventCategoryWriteRepository _eventCategoryWriteRepository = eventCategoryWrite;                                  


        public async Task<ResponseModel<CreateEventCategoryResponse>> Handle(CreateEventCategoryRequest request, CancellationToken cancellationToken)
        {
         
            if (request == null) throw new BadRequestException("Request is null");


            var category = mapper.Map<Category>(request);

            try
            {
                await _eventCategoryWriteRepository.AddAsync(category);
                await _eventCategoryWriteRepository.SaveChangesAsync();

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                
            }
            var response = mapper.Map<CreateEventCategoryResponse>(category);
            Console.WriteLine(response.CategoryId);
            //Console.WriteLine("Request geldi ve catdi db yoxla");
            return new ResponseModel<CreateEventCategoryResponse>
            {
                Data = response,
                Message="Create Category"
            };




        }
    }
}
