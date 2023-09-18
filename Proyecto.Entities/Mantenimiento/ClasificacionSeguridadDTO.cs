using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionSeguridadDTO
    {
        public int ClasificacionSeguridadId { get; set; }
        public string? DescClasificacionSeguridad { get; set; }
        public string? CodigoClasificacionSeguridad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
