using EventProject.Application.DTOs;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.VenueCommands.CreateVenue;

public class CreateVenueRequest:IRequest<ResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Address { get; set; }

    public string?  Description { get; set; }

    public string Phone {  get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public List<SeatDTO> Seats { get; set; }

}


