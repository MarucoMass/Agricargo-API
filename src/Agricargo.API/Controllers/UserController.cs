﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agricargo.Application.Interfaces;
using Agricargo.Application.Models.Requests;

namespace Agricargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(UpdateUserRequest userRequest) 
        {
            try
            {
                _userService.UpdateUser(userRequest, User);
                return Ok("Se actualizo el usuario");
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

        [HttpDelete("DeleteSelf")]
        public IActionResult DeleteSelf() 
        {
            try
            {
                _userService.DeleteSelf(User);
                return Ok("Usuario eliminado");
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

        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            try
            {
                var userfind = _userService.GetUserInfo(User);
                return Ok(userfind);
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

        [HttpGet("GetUsers")]
        public IActionResult GetUsers() 
        {
            try
            {
                var users = _userService.GetUsers(User);
                return Ok(users);
            }
            catch (Exception ex)
            { 
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(string idUser)
        {
            try
            {
                _userService.DeleteUser(User, idUser);
                return Ok("Eliminado con exito");
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
