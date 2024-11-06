

using Agricargo.Domain.Entities;
using System.Security.Claims;
using Agricargo.Application.Models.DTOs;

namespace Agricargo.Application.Interfaces;

public interface IFavoriteService
{
    public int AddFavorite(ClaimsPrincipal user, int tripId);

    public int DeleteFavorite(ClaimsPrincipal user, int id);

    public List<TripDTO> GetFavorites(ClaimsPrincipal user);
}
