using EventProject.Application.DTOs;
using EventProject.Application.Features.Commands.VenueCommands.CreateVenue;
using EventProject.Application.Features.Commands.VenueCommands.DeleteVenue;
using EventProject.Application.Features.Commands.VenueCommands.UpdateVenue;
using EventProject.Application.Features.Commands.VenueMediaFile.UploadVenueMedia;
using EventProject.Application.Features.Queries.VenueQueries.GetAllVenueQueries;
using EventProject.Application.Features.Queries.VenueQueries.GetByIdVenueQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly IMediator _mediator;

    public VenueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateVenue([FromBody] CreateVenueRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }   
      
    [HttpPut("update")] 
    public async Task<IActionResult> UpdateVenue([FromBody] UpdateVenueRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllVenue()
    {
        var result = await _mediator.Send(new GetAllVenueRequest());
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetByIdVenue([FromQuery]GetByIdVenueRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteVenue([FromQuery] DeleteVenueRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpPost("uploadVenueMedia")]
    public async Task<IActionResult> UploadVenueMedia([FromForm] UploadVenueMediaRequest request)
    {
        return Ok(await _mediator.Send(request));   
    }



}