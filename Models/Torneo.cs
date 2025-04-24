using System.ComponentModel.DataAnnotations;

namespace TorneosApi.Models
{
    public class Torneo
    {
        [Key]
        public int idTorneos { get; set; }
        public int idAdministradorITM { get; set; }
        public string TipoTorneo { get; set; }
        public string NombreTorneo { get; set; }
        public string NombreEquipo { get; set; }
        public int ValorInscripcion { get; set; }
        public DateTime FechaTorneo { get; set; }
        public string Integrantes { get; set; }
    }
}