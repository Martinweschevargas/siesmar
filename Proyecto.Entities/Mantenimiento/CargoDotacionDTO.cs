using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CargoDotacionDTO
    {
        public int CargoDotacionId { get; set; }
        public string? DescCargoDotacion { get; set; }
        public string? CodigoCargoDotacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
