﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
// 
public class CreateEventCategoryRequest:IRequest<ResponseModel<CreateEventCategoryResponse>>
{
}
