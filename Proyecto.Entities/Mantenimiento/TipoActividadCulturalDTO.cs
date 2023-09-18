using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoActividadCulturalDTO
    {
        public int TipoActividadCulturalId { get; set; }
        public string? DescTipoActividadCultural { get; set; }
        public string? CodigoTipoActividadCultural { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
