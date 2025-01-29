
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solteq.server.services;

namespace Solteq_server.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var result = await _authService.RegisterAsync(request.Username, request.Password);
            if (result == "Username already exists")
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var token = await _authService.LoginAsync(request.Username, request.Password);

            if (token == "Invalid Credentials")
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new { Token = token });
        }
    }
}
