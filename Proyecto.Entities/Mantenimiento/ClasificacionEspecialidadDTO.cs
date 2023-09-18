using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionEspecialidadDTO
    {
        public int ClasificacionEspecialidadId { get; set; }
        public string? DescClasificacionEspecialidad { get; set; }
        public string? AbrevClasificacionEspecialidad { get; set; }
        public string? CodigoClasificacionEspecialidad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
