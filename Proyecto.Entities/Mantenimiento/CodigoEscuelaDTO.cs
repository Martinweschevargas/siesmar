using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CodigoEscuelaDTO
    {
        public int CodigoEscuelaId { get; set; }
        public string? DescCodigoEscuela { get; set; }
        public string? CodigoCodigoEscuela { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
