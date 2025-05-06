using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Package_Api.Models.Login;
using Package_Api.Services;

namespace Package_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserLogin user)
        {
            if (await _authService.RegisterUser(user))
            {
                return Ok("User registered");
            }
            return BadRequest("User registration failed");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _authService.Login(user))
            {
                var tokenString = _authService.GenerateTokenString(user);
                return Ok("Login successful! Your token is:\n" + tokenString);
            }
            return BadRequest();
        }
    }
}
