using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionInspeccionDTO
    {
        public int ClasificacionInspeccionId { get; set; }
        public string? DescClasificacionInspeccion { get; set; }
        public string? CodigoClasificacionInspeccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
