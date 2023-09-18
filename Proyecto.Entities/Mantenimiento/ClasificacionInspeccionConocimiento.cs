using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionInspeccionConocimientoDTO
    {
        public int ClasificacionInspeccionConocimientoId { get; set; }
        public string? DescClasificacionInspeccionConocimiento { get; set; }
        public string? CodigoClasificacionInspeccionConocimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
