using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoRacionDTO
    {
        public int TipoRacionId { get; set; }
        public string? DescTipoRacion { get; set; }
        public string? CodigoTipoRacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
