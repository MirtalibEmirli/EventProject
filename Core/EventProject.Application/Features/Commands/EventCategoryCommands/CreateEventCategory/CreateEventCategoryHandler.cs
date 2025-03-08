using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory
{
    public class CreateEventCategoryHandler(IEventCategoryWriteRepository eventCategoryWrite) : IRequestHandler<CreateEventCategoryRequest, ResponseModel<CreateEventCategoryResponse>>
    {
        private readonly IEventCategoryWriteRepository _eventCategoryWriteRepository =eventCategoryWrite;                                //bunu silede bilerik isdesez   


        public async Task<ResponseModel<CreateEventCategoryResponse>> Handle(CreateEventCategoryRequest request, CancellationToken cancellationToken)
        {
            //Afet bu yoxlanis kodudur sadece MediatR i yoxlayrdim isleyir 
            //repositoryni qos database e add ed fso bnu sile bilersen.


            if (request == null) throw new BadRequestException("Request is null");



            Console.WriteLine("Request geldi ve catdi db yoxla");
            return new ResponseModel<CreateEventCategoryResponse>
            {
                Data = new CreateEventCategoryResponse()
                {
                    CategoryId = "1",
                },
                IsSucces = true
            };
            



        }
    }
}
