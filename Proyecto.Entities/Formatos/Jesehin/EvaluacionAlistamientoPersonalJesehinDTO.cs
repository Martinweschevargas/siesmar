using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Jesehin
{
    public partial class EvaluacionAlistamientoPersonalJesehinDTO
    {

        public int? EvaluacionAlistamientoPersonalId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaEvaluacion { get; set; }
        public int? DNIPersonal { get; set; }
        public int? CIPPersonal { get; set; }
        public string? Cargo { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public int? GradoPersonalMilitarActual { get; set; }
        public int? EspecialidadGenericaPersonalActual { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; } 
        public decimal? PuntajeTotalPersonal { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescGradoPersonalMilitarActual { get; set; }
        public string? DescEspecialidadGenericaPersonalActual { get; set; } 
 
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
