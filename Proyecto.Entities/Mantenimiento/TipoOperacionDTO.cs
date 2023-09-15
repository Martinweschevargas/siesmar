using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoOperacionDTO
    {
        public int TipoOperacionId { get; set; }
        public string? DescTipoOperacion { get; set; }
        public string? Operacion { get; set; }
        public string? CodigoTipoOperacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
