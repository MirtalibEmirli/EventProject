using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.UpdateEventCategory;

    public class UpdateEventCategoryRequest:IRequest<ResponseModel<UpdateEventCategoryResponse>>
    {
	    public string Id { get; set; }
	    public string CategoryName { get; set; } 
	    public string? Description { get; set; }
    }
