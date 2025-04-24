using Microsoft.AspNetCore.Mvc;
using TorneosApi.Models;
using TorneosApi.Services;

namespace TorneosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            var token = _authService.Authenticate(login.Usuario, login.Clave);
            if (token == null)
                return Unauthorized("Usuario o clave incorrectos");

            return Ok(new { token });
        }
    }
}
