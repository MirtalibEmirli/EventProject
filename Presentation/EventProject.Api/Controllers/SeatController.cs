using EventProject.Application.Features.Commands.SeatCommands;
using EventProject.Application.Features.Commands.SeatCommands.CreateSeats;
using EventProject.Application.Features.Commands.SeatCommands.DeleteSeatsById;
using EventProject.Application.Features.Commands.SeatCommands.DeleteSeatsByVenue;
using EventProject.Application.Features.Queries.EventSeatQueries;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;


[ApiController]
[Route("api/venues/{venueId}/seats")]
public class SeatController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeatController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("upload")]
    public async Task<IActionResult> UploadSeats([FromForm] CreateSeatRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseModel<GetSeatsByVenueResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSeatsByVenue(Guid venueId)
    {
        var result = await _mediator.Send(new GetSeatsByVenueQuery(venueId));
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeleteSeatsByVenueResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteSeatsByVenue(Guid venueId)
    {
        var request = new DeleteSeatsByVenueRequest() { VenueId=venueId};
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("{seatId}")]
    [ProducesResponseType(typeof(DeleteSeatsByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSeatById(Guid seatId)
    {
        var result = await _mediator.Send(new DeleteSeatsByIdRequest() { SeatId=seatId});

        if (!result.IsDeleted)
            return NotFound(new { Message = $"Seat with id {seatId} not found." });

        return Ok(result);
    }

}
