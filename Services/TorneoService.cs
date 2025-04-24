using TorneosApi.Data;
using TorneosApi.DTOs;
using TorneosApi.Models;

namespace TorneosApi.Services
{
    public class TorneoService
    {
        private readonly ApplicationDbContext _context;

        public TorneoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TorneoDto CreateTorneo(CreateTorneoDto dto)
        {
            var torneo = new Torneo
            {
                idAdministradorITM = dto.idAdministradorITM,
                TipoTorneo = dto.TipoTorneo,
                NombreTorneo = dto.NombreTorneo,
                NombreEquipo = dto.NombreEquipo,
                ValorInscripcion = dto.ValorInscripcion,
                FechaTorneo = dto.FechaTorneo,
                Integrantes = dto.Integrantes
            };

            _context.Torneos.Add(torneo);
            _context.SaveChanges();

            return new TorneoDto
            {
                idTorneos = torneo.idTorneos,
                TipoTorneo = torneo.TipoTorneo,
                NombreTorneo = torneo.NombreTorneo,
                NombreEquipo = torneo.NombreEquipo,
                ValorInscripcion = torneo.ValorInscripcion,
                FechaTorneo = torneo.FechaTorneo,
                Integrantes = torneo.Integrantes
            };
        }

        public TorneoDto GetTorneoById(int id)
        {
            var torneo = _context.Torneos.Find(id);
            if (torneo == null) return null;

            return new TorneoDto
            {
                idTorneos = torneo.idTorneos,
                TipoTorneo = torneo.TipoTorneo,
                NombreTorneo = torneo.NombreTorneo,
                NombreEquipo = torneo.NombreEquipo,
                ValorInscripcion = torneo.ValorInscripcion,
                FechaTorneo = torneo.FechaTorneo,
                Integrantes = torneo.Integrantes
            };
        }

        public IEnumerable<TorneoDto> GetTorneos(string tipo, string nombre, DateTime? fecha)
        {
            var query = _context.Torneos.AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(t => t.TipoTorneo == tipo);

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(t => t.NombreTorneo.Contains(nombre));

            if (fecha.HasValue)
                query = query.Where(t => t.FechaTorneo == fecha.Value);

            return query.Select(t => new TorneoDto
            {
                idTorneos = t.idTorneos,
                TipoTorneo = t.TipoTorneo,
                NombreTorneo = t.NombreTorneo,
                NombreEquipo = t.NombreEquipo,
                ValorInscripcion = t.ValorInscripcion,
                FechaTorneo = t.FechaTorneo,
                Integrantes = t.Integrantes
            }).ToList();
        }

        public bool UpdateTorneo(int id, UpdateTorneoDto dto)
        {
            var torneo = _context.Torneos.Find(id);
            if (torneo == null) return false;

            torneo.TipoTorneo = dto.TipoTorneo;
            torneo.NombreTorneo = dto.NombreTorneo;
            torneo.NombreEquipo = dto.NombreEquipo;
            torneo.ValorInscripcion = dto.ValorInscripcion;
            torneo.FechaTorneo = dto.FechaTorneo;
            torneo.Integrantes = dto.Integrantes;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteTorneo(int id)
        {
            var torneo = _context.Torneos.Find(id);
            if (torneo == null) return false;

            _context.Torneos.Remove(torneo);
            _context.SaveChanges();
            return true;
        }
    }
}
