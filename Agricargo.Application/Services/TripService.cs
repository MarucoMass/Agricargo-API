﻿

using Agricargo.Application.Interfaces;
using Agricargo.Application.Models.DTOs;
using Agricargo.Application.Models.Requests;
using Agricargo.Application.Models.RequestsM;
using Agricargo.Domain.Entities;
using Agricargo.Domain.Interfaces;
using Agricargo.Infrastructure.Data.Repositories;
using System.Security.Claims;

namespace Agricargo.Application.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;
    private readonly IShipService _shipService;

    public TripService(ITripRepository tripRepository, IShipService shipService)
    {
        _tripRepository = tripRepository;
        _shipService = shipService;
    }

    private Guid GetCompanyIdFromUser(ClaimsPrincipal user)
    {
        var userId = user.FindFirst("id")?.Value;

        if (!Guid.TryParse(userId, out Guid parsedGuid))
        {
            throw new UnauthorizedAccessException("Token inválido");
        }

        return parsedGuid;
    }

    public void Add(TripCreateRequest tripService, ClaimsPrincipal user)
    {
        var userId = GetCompanyIdFromUser(user);

        bool isShipOwned = _shipService.IsShipOwnedByCompany(tripService.ShipId, userId);

        Ship ship = _shipService.Get(user, tripService.ShipId);

        if (!isShipOwned)
        {
            throw new UnauthorizedAccessException("Barco no asociado a la empresa");
        }

        foreach (var trip in ship.Trips)
        {
            if ((tripService.DepartureDate <= trip.ArriveDate) && (tripService.ArriveDate >= trip.DepartureDate))
            {
                Console.WriteLine(ship);
                throw new Exception("El barco ya tiene un viaje para esa fecha");
            }
        }

        _tripRepository.Add(new Trip
        {
            Origin = tripService.Origin,
            Destination = tripService.Destination,
            DepartureDate = tripService.DepartureDate,
            ArriveDate = tripService.ArriveDate,
            Price = tripService.Price,
            ShipId = tripService.ShipId,
            AvailableCapacity = ship.Capacity
        });



    }

    public void Delete(int id, ClaimsPrincipal user)
    {
        var trip = _tripRepository.Get(id);

        if (trip == null)
        {
            throw new Exception("Viaje no encontrado");
        }
        var trips = GetTrips(user);
        if (!trips.Any(t => t.Id == id))
        {
            throw new UnauthorizedAccessException("No tienes permiso de eliminar este viaje");
        }
        _tripRepository.Delete(trip);
    }

    public Trip Get(int id)
    {
        var trip = _tripRepository.Get(id);
        return trip;
    }

    public List<TripDTO> Get(TripSearchRequest tripSearch, out string searchType)
    {
        var exactGet = _tripRepository.Get()
            .Where(t => t.Origin == tripSearch.Origin
                        && t.Destination == tripSearch.Destination
                        && tripSearch.GrainAmount <= t.AvailableCapacity)
            .Select(t => new TripDTO
            {
                Id = t.Id,
                Origin = t.Origin,
                Destination = t.Destination,
                PricePerTon = t.Price,
                DepartureDate = t.DepartureDate,
                ArriveDate = t.ArriveDate,
                Capacity = t.AvailableCapacity
            })
            .ToList();

        if (exactGet.Any())
        {
            searchType = "ExactSearch";
            return exactGet;
        }

        var partialGet = _tripRepository.Get()
            .Where(t => (t.Origin == tripSearch.Origin || t.Destination == tripSearch.Destination)
                        && tripSearch.GrainAmount <= t.AvailableCapacity)
            .Select(t => new TripDTO
            {
                Id = t.Id,
                Origin = t.Origin,
                Destination = t.Destination,
                PricePerTon = t.Price,
                DepartureDate = t.DepartureDate,
                ArriveDate = t.ArriveDate,
                Capacity = t.AvailableCapacity
            })
            .ToList();

        searchType = "PartialSearch";
        return partialGet;
    }


    public void Update(int id, TripUpdateRequest tripRequest, ClaimsPrincipal user)
    {
        var trip = _tripRepository.Get(id);
        if (trip == null)
        {
            throw new Exception("Viaje no encontrado");
        }
        var trips = GetTrips(user);

        if (!trips.Any(t => t.Id == id))
        {
            throw new UnauthorizedAccessException("No tienes permiso a realizar esta accion");
        }
        Ship ship = _shipService.Get(user, trip.ShipId);

        foreach (var tripOfShip in ship.Trips)
        {
            if ((tripRequest.DepartureDate <= tripOfShip.ArriveDate) && (tripRequest.ArriveDate >= tripOfShip.DepartureDate))
            {
                Console.WriteLine(ship);
                throw new Exception("El barco ya tiene un viaje para esa fecha");
            }
        }

        trip.Origin = tripRequest.Origin;
        trip.Destination = tripRequest.Destination;
        trip.DepartureDate = tripRequest.DepartureDate;
        trip.ArriveDate = tripRequest.ArriveDate;
        trip.Price = tripRequest.Price;

        _tripRepository.Update(trip);

    }

    public List<TripDTO> GetTrips(ClaimsPrincipal user)
    {
        var userId = GetCompanyIdFromUser(user);

        var trips = _tripRepository.GetCompanyTrips(userId);

        if (trips == null || !trips.Any())
        {
            throw new Exception("No se encontraron viajes para la empresa.");
        }

        foreach (var trip in trips)
        {
            var currentDate = DateTime.Now;

            // Actualizar el estado del viaje según las fechas
            if (currentDate < trip.DepartureDate)
            {
                trip.TripState = "Pendiente";  // El viaje aún no ha comenzado
            }
            else if (currentDate >= trip.DepartureDate && currentDate <= trip.ArriveDate)
            {
                trip.TripState = "En curso";  // El viaje está en progreso
            }
            else if (currentDate > trip.ArriveDate)
            {
                trip.TripState = "Completado";  // El viaje ha finalizado
            }

            // Actualizar el viaje con el nuevo estado
            _tripRepository.Update(trip);
        }

        return trips.Select(t => new TripDTO
        {
            Id = t.Id,
            Origin = t.Origin,
            Destination = t.Destination,
            PricePerTon = t.Price,
            DepartureDate = t.DepartureDate,
            ArriveDate = t.ArriveDate,
            Capacity = t.Ship.Capacity
        }).ToList();
    }

    public List<Trip> GetTripsOfShips(ClaimsPrincipal user, int id)
    {
        var companyId = GetCompanyIdFromUser(user);
        GetTrips(user);
        if (_shipService.IsShipOwnedByCompany(id, companyId))
        {
            var trips = _tripRepository.GetTripsOfShip(id);
            return trips;
        }

        return new List<Trip>();

    }


}
