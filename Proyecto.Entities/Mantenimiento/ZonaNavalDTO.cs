using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ZonaNavalDTO
    {
        public int ZonaNavalId { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? CodigoZonaNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
