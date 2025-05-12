using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Package_Api.Models.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Package_Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> RegisterUser(UserLogin user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.Username,
                Email = user.Username
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }

        public async Task<bool> Login(UserLogin user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Username);
            
            if (identityUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public string GenerateTokenString(UserLogin user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Username),
            };

            var securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SecretKey").Value));
            
            var signingCred = new SigningCredentials
                (securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddHours(1),
                issuer:_configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials:signingCred);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
