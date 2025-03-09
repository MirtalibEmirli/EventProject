using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;

public class DeleteEventCategoryRequest:IRequest<ResponseModel<DeleteEventCategoryResponse>>
{
    public string Id { get; set; }
}
