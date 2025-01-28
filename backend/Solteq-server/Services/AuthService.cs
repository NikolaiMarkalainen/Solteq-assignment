

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Solteq_server.data;
using Solteq_server.models;

namespace Solteq.server.services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
    
    public async Task<string> RegisterAsync(string username, string password)
        {
            if (await _context.User.AnyAsync(u => u.Username == username))
            {
                return "Username already exists";
            };

            var user = new User
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return "User saved successfully";
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return "Invalid Credentials";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}