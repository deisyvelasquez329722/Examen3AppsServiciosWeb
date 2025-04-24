using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneosApi.Models
{
    [Table("AdministradorITM")]
    public class Admin
    {
        [Key]
        public int idAdministradorITM { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}