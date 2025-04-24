namespace TorneosApi.DTOs
{
    public class UpdateTorneoDto
    {
        public string TipoTorneo { get; set; }
        public string NombreTorneo { get; set; }
        public string NombreEquipo { get; set; }
        public int ValorInscripcion { get; set; }
        public DateTime FechaTorneo { get; set; }
        public string Integrantes { get; set; }
    }
}
