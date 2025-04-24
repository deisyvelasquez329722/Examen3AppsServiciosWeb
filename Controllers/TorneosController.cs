using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TorneosApi.DTOs;
using TorneosApi.Services;

namespace TorneosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TorneosController : ControllerBase
    {
        private readonly TorneoService _torneoService;

        public TorneosController(TorneoService torneoService)
        {
            _torneoService = torneoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTorneoDto dto)
        {
            var torneo = _torneoService.CreateTorneo(dto);
            return CreatedAtAction(nameof(GetById), new { id = torneo.idTorneos }, torneo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var torneo = _torneoService.GetTorneoById(id);
            if (torneo == null) return NotFound();
            return Ok(torneo);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? tipo, [FromQuery] string? nombre, [FromQuery] DateTime? fecha)
        {
            var torneos = _torneoService.GetTorneos(tipo, nombre, fecha);
            return Ok(torneos);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTorneoDto dto)
        {
            var result = _torneoService.UpdateTorneo(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _torneoService.DeleteTorneo(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
