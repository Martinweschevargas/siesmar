using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAfiliacionDTO
    {
        public int TipoAfiliacionId { get; set; }
        public string? DescTipoAfiliacion { get; set; }
        public string? CodigoTipoAfiliacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
