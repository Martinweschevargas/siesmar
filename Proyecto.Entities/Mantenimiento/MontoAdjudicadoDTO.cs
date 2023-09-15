using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MontoAdjudicadoDTO
    {
        public int MontoAdjudicadoId { get; set; }
        public string? DescMontoAdjudicado { get; set; }
        public string? CodigoMontoAdjudicado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
