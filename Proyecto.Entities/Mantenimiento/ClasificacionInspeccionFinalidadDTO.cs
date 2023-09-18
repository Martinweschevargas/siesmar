using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionInspeccionFinalidadDTO
    {
        public int ClasificacionInspeccionFinalidadId { get; set; }
        public string? DescClasificacionInspeccionFinalidad { get; set; }
        public string? CodigoClasificacionInspeccionFinalidad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
