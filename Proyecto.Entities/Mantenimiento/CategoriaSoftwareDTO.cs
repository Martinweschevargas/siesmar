using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CategoriaSoftwareDTO
    {
        public int CategoriaSoftwareId { get; set; }
        public string? DescCategoriaSoftware { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
