﻿using Agricargo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ClientPolicy")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("getFavorites")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_favoriteService.GetFavorites(User));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("addFavorite")]
        public IActionResult Post([FromBody] int tripId)
        {
            try
            {
                _favoriteService.AddFavorite(User, tripId);
                return Ok("Favorito agregado");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteFavorite/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                 _favoriteService.DeleteFavorite(User, id);
                return Ok("Favorito eliminado");
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
}
