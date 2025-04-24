using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TorneosApi.Data;
using TorneosApi.Models;

namespace TorneosApi.Services
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

        public string Authenticate(string usuario, string clave)
        {
            var admin = _context.Administradores
                .FirstOrDefault(a => a.Usuario == usuario && a.Clave == clave);

            if (admin == null)
                return null;

            // Crear claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, admin.Usuario),
                new Claim("idAdministradorITM", admin.idAdministradorITM.ToString())
            };

            // Configuración del token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
