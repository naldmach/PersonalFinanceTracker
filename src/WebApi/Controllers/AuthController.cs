// src/WebApi/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Services;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authService;
        private readonly JwtService _jwtService;
        
        public AuthController(AuthenticationService authService, JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] UserRegistrationDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            try
            {
                var user = await _authService.RegisterAsync(request);
                var token = _jwtService.GenerateToken(user);
                
                return Ok(new AuthResponseDto
                {
                    Token = token,
                    User = new UserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.Name
                    }
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserLoginDto request)
        {
            var user = await _authService.ValidateUserAsync(request);
            
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });
                
            var token = _jwtService.GenerateToken(user);
            
            return Ok(new AuthResponseDto
            {
                Token = token,
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name
                }
            });
        }
    }
}