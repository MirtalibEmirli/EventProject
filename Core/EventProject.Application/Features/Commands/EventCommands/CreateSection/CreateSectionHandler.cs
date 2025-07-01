using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventCommands.CreateSection;


public class CreateSectionRequest:IRequest<ResponseModel<Unit>>
{
    public string Name { get; set; }//bununla sectiona post gedr section yaradilir id sin goturruk 

    public string Price { get; set; }

    public Guid EventId { get; set; }//buuda selectboxdan gelecek olan id di
    //Sectionid evvnettid ve price ilede section price yaaradilir vse 

}

public class CreateSectionHandler : IRequestHandler<CreateSectionRequest, ResponseModel<Unit>>
{
    public Task<ResponseModel<Unit>> Handle(CreateSectionRequest request, CancellationToken cancellationToken)
    {



        throw new NotImplementedException();
    }
}
