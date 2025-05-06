using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Package_Api.DTOs.Login;

namespace Package_Api.Controllers
{
    public class AuthController : ControllerBase
    {
        // Injections
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest model)
        {
            // Validate the user credentials (use the IUserService to fetch the user from the DB)
            var user = _userService.ValidateUser(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials"); // If user is not found or credentials don't match
            }

            // Create claims for the JWT (Now we have access to the user object)
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),  // User's username
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())  // User's ID from the database
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),  // Set expiration for the token
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { Token = tokenString });  // Return the token as part of the response
        }
    }
}
