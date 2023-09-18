using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EspecialidadPostulacionDTO
    {
        public int EspecialidadPostulacionId { get; set; }
        public string? DescEspecialidadPostulacion { get; set; }
        public string? AbrevEspecialidadPostulacion { get; set; }
        public string? ProfesionalEspecialidadPostulacion { get; set; }
        public string? CodigoEspecialidadPostulacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
