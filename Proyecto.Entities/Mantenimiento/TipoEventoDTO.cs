using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoEventoDTO
    {
        public int TipoEventoId { get; set; }
        public string? DescTipoEvento { get; set; }
        public string? CodigoTipoEvento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
