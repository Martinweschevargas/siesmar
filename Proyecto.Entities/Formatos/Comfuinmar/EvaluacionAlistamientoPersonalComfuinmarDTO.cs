using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuinmar
{
    public partial class EvaluacionAlistamientoPersonalComfuinmarDTO
    {

        public int? EvaluacionAlistamientoPersonalId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? FechaEvaluacion { get; set; }
        public string? DNIPersonal { get; set; }
        public string? CIPPersonal { get; set; }
        public string? CodigoCargo { get; set; }
        public string? CodigoGradoPersonalMilitarEsperado { get; set; }
        public string? CodigoEspecialidadGenericaPersonalEsperado { get; set; }
        public string? CodigoGradoPersonalMilitarActual { get; set; }
        public string? CodigoEspecialidadGenericaPersonalActual { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescCargo { get; set; }
        public string? DescGradoEsperado { get; set; }
        public string? DescEspecialidadEsperado { get; set; }
        public string? DescGradoActual { get; set; } 
        public string? DescEspecialidadActual { get; set; } 

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
