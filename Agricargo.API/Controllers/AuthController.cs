﻿using Agricargo.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agricargo.Application.Models;
using Agricargo.Application.Models.Requests;
using Agricargo.Domain.Interfaces;
using Agricargo.Application.Interfaces;

namespace Agricargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = _authService.Login(request.Email, request.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = _authService.Register(request.Email, request.Password, request.Role, request.Name, request.SysId, request.CompanyName);
            if (!result)
            {
                return BadRequest("User already exists");
            }

            return Ok("User registered successfully");
        }
    }
}
