using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoActividadDifusionDTO
    {
        public int TipoActividadDifusionId { get; set; }
        public string? DescTipoActividadDifusion { get; set; }
        public string? CodigoTipoActividadDifusion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
