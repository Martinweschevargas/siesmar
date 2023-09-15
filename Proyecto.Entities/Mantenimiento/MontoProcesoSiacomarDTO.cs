using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MontoProcesoSiacomarDTO
    {
        public int MontoProcesoSiacomarId { get; set; }
        public string? DescMontoProcesoSiacomar { get; set; }
        public string? CodigoMontoProcesoSiacomar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
