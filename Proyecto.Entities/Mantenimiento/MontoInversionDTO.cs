using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MontoInversionDTO
    {
        public int MontoInversionId { get; set; }
        public string? DescMontoInversion { get; set; }
        public string? CodigoMontoInversion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
