

using Agricargo.Application.Interfaces;
using Agricargo.Domain.Entities;
using Agricargo.Domain.Interfaces;
using System.Security.Claims;
using Agricargo.Application.Models.DTOs;

namespace Agricargo.Application.Services;

public class FavoriteService : IFavoriteService
{
    private readonly ITripService _tripService;
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoriteService(IFavoriteRepository favoriteRepository, ITripService tripService)
    {
        _favoriteRepository = favoriteRepository;
        _tripService = tripService;
    }

    private Guid GetIdFromUser(ClaimsPrincipal user)
    {
        var userId = user.FindFirst("id")?.Value;

        if (!Guid.TryParse(userId, out Guid parsedGuid))
        {
            throw new UnauthorizedAccessException("Token inválido");
        }

        return parsedGuid;
    }
    public void AddFavorite(ClaimsPrincipal user, int tripId)
    {
        var trip = _tripService.Get(tripId);

        if (trip is null)
        {
            throw new Exception("Viaje no encontrado");
        }

        var clientId = GetIdFromUser(user);

        var existingFavorite = _favoriteRepository.GetFavoriteByClientAndTrip(clientId, tripId);

        if (existingFavorite is not null)
        {
            throw new Exception("El viaje ya está en la lista de favoritos.");
        }

        var favorite = new Favorite
        {
            ClientId = clientId,
            TripId = tripId,
            Trip = trip
        };

        _favoriteRepository.Add(favorite);

    }

    public List<TripDTO> GetFavorites(ClaimsPrincipal user)
    {
        var clientId = GetIdFromUser(user);

        var favorites = _favoriteRepository.GetClientFavorites(clientId);

        if (favorites == null || !favorites.Any())
        {
            throw new Exception("No se encontraron favoritos");
        }

        //return favorites.Select(f => new FavoriteDTO
        //{
        //    Id = f.Id,
        //    Trip = new TripDTO
        //    {
        //        Id = f.Trip.Id,
        //        Origin = f.Trip.Origin,
        //        Destination = f.Trip.Destination,
        //        PricePerTon = f.Trip.Price,
        //        DepartureDate = f.Trip.DepartureDate,
        //        ArriveDate = f.Trip.ArriveDate,
        //        Capacity = f.Trip.AvailableCapacity,
        //        Ship = new ShipDTO
        //        {
        //            Id = f.Trip.Ship.Id,
        //            TypeShip = f.Trip.Ship.TypeShip,
        //            Capacity = f.Trip.Ship.Capacity,
        //            Captain = f.Trip.Ship.Captain,
        //            ShipPlate = f.Trip.Ship.ShipPlate,
        //            Status = f.Trip.Ship.AvailabilityStatus,
        //            Company = new CompanyDTO
        //            {
        //                Name = f.Trip.Ship.Company.Name,
        //                CompanyName = f.Trip.Ship.Company.CompanyName
        //            }
        //        }

        //    }
        //}
        //).ToList();

        return favorites.Select(f => new TripDTO
            {
                Id = f.Trip.Id,
                Origin = f.Trip.Origin,
                Destination = f.Trip.Destination,
                PricePerTon = f.Trip.Price,
                DepartureDate = f.Trip.DepartureDate,
                ArriveDate = f.Trip.ArriveDate,
                Capacity = f.Trip.AvailableCapacity,
                FavId = f.Id,
                Ship = new ShipDTO
                {
                    Id = f.Trip.Ship.Id,
                    TypeShip = f.Trip.Ship.TypeShip,
                    Capacity = f.Trip.Ship.Capacity,
                    Captain = f.Trip.Ship.Captain,
                    ShipPlate = f.Trip.Ship.ShipPlate,
                    Status = f.Trip.Ship.AvailabilityStatus,
                    Company = new CompanyDTO
                    {
                        Name = f.Trip.Ship.Company.Name,
                        CompanyName = f.Trip.Ship.Company.CompanyName
                    }
                }
        }
        ).ToList();
    }


    public void DeleteFavorite(ClaimsPrincipal user, int id)
    {
        var clientId = GetIdFromUser(user);

        var favorite = _favoriteRepository.GetFavoriteById(id);


        if (favorite == null)
        {
            throw new Exception("Favorito no encontrado.");
        }

        if (favorite.ClientId != clientId)
        {
            throw new UnauthorizedAccessException("No tienes permiso para eliminar este favorito.");
        }

        _favoriteRepository.Delete(favorite);


    }
}
