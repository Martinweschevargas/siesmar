using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CursoCapacitacionPSubalternoDTO
    {
        public int CursoCapacitacionPSubalternoId { get; set; }
        public string? DescCursoCapacitacion { get; set; }
        public string? CodigoCursoCapacitacion { get; set; }
        public string? DuracionCursoCapacitacion { get; set; }
        public string? InicioTerminoCursoCapacitacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
