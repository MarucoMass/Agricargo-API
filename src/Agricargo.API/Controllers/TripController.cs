﻿
using Agricargo.Application.Interfaces;
using Agricargo.Application.Models.Requests;
using Agricargo.Application.Models.RequestsM;
using Agricargo.Application.Services;
using Agricargo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Agricargo.API.Controllers;

[ApiController]
[Route("[controller]")]

public class TripController : ControllerBase
{
    private ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpPost("addTrip")]
    [Authorize(Policy = "AdminPolicy")]
    public ActionResult Post([FromBody] TripCreateRequest tripRequest)
    {
        try
        {
            _tripService.Add(tripRequest, User);
            return Ok("Creado");
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex) 
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("getTrips")]
    public ActionResult Get([FromQuery] TripSearchRequest tripSearch)
    {
        string searchType;
        var trips = _tripService.Get(tripSearch, out searchType);

        string message = searchType == "ExactSearch" ? "Búsqueda exacta exitosa:" : "Búsqueda parcial exitosa:";

        if (!trips.Any()) { return Ok("No se encontraron viajes"); }

        var result = new
        {
            Message = message,
            Trips = trips
        };

        return Ok(result);
    }

    [HttpGet("getTrip/{id}")]
    public ActionResult GetTrip(int id)
    {
        try
        {
            return Ok(_tripService.GetToDto(User, id));
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex) 
        {
            return NotFound(ex.Message); 
        }
    }

    [HttpPut("updateTrip/{id}")]
    public ActionResult Update(int id, [FromBody] TripUpdateRequest tripRequest)
    {
        try
        {
            _tripService.Update(id, tripRequest, User);
            return Ok("Actualizado");
        }catch (UnauthorizedAccessException ex){
            return Unauthorized(ex.Message);
        }catch (Exception ex){
            return NotFound(ex.Message);        
        }
        
    }

    [HttpDelete("deleteTrip/{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            _tripService.Delete(id, User);
            return Ok("Borrado");
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex) 
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("getCompanyTrips")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult GetCompanyTrips()
    {
        try
        {
            var trips  = _tripService.GetTrips(User);
            return Ok(trips);
        }
        catch (UnauthorizedAccessException ex) 
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("getTripsOfShip")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult GetTripsOfShip(int id)
    {
        try
        {
            var trips = _tripService.GetTripsOfShips(User, id);
            return Ok(trips);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}

