using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionInspeccionExtensionDTO
    {
        public int ClasificacionInspeccionExtensionId { get; set; }
        public string? DescClasificacionInspeccionExtension { get; set; }
        public string? CodigoClasificacionInspeccionExtension { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
