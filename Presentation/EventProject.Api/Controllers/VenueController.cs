using EventProject.Application.DTOs;
using EventProject.Application.Features.Commands.VenueCommands.CreateVenue;
using EventProject.Application.Features.Commands.VenueCommands.DeleteVenue;
using EventProject.Application.Features.Commands.VenueCommands.UpdateVenue;
using EventProject.Application.Features.Commands.VenueMediaFile.DeleteVenueMedia;
using EventProject.Application.Features.Commands.VenueMediaFile.UploadVenueMedia;
using EventProject.Application.Features.Queries.VenueQueries.GetAllVenueQueries;
using EventProject.Application.Features.Queries.VenueQueries.GetByIdVenueQueries;
using EventProject.Application.Features.Queries.VenueQueries.GetVenueMedia;
using EventProject.Application.Features.Queries.VenueQueries.Getvenuesforselectbox;
using EventProject.Application.Features.Queries.VenueQueries.Search;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.API.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly IMediator _mediator;

    public VenueController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [AllowAnonymous]
    [HttpGet("getvenuesforselectbox")]
    public async Task<IActionResult> GetVenuesForSelect()
    {
        var result = await _mediator.Send(new GetvenuesforselectboxQuery());
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("getVenueMediaFiles/{id}")]
    public async Task<IActionResult> GetVenueMediaFiles(Guid id)
    {
        var result = await _mediator.Send(new GetVenueMediasQuery(id));
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }   
    [HttpPost("create")]
    public async Task<IActionResult> CreateVenue([FromBody] CreateVenueRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateVenue([FromBody] UpdateVenueRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }
    [AllowAnonymous]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllVenue()
    {
        var result = await _mediator.Send(new GetAllVenueRequest());
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
    [AllowAnonymous]
    [HttpGet("getById")]
    public async Task<IActionResult> GetByIdVenue([FromQuery] GetByIdVenueRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteVenue([FromQuery] DeleteVenueRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("uploadVenueMedia")]
    public async Task<IActionResult> UploadVenueMedia([FromForm] UploadVenueMediaRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [HttpPut("deletevenuemedia")]
    public async Task<IActionResult> DeleteVenueMedia([FromQuery] string fileName)
    {
        var result = await _mediator.Send(new DeleteVenueMediaRequest(fileName));
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("searchelements")]
    public async Task<IActionResult> Search([FromQuery] string searchText)
    {
        var result = await _mediator.Send(new SearchRequest(searchText));
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }


}