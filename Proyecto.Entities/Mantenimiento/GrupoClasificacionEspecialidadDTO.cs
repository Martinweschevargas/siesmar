using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoClasificacionEspecialidadDTO
    {
        public int GrupoClasificacionEspecialidadId { get; set; }
        public string? DescGrupoClasificacionEspecialidad { get; set; }
        public string? CodigoGrupoClasificacionEspecialidad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
