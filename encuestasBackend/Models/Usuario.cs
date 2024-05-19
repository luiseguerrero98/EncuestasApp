using System.ComponentModel.DataAnnotations;

namespace encuestasBackend.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contraseniaHash { get; set; }
    }
}