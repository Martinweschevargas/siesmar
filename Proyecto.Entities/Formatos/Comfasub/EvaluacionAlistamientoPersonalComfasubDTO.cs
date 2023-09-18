using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class EvaluacionAlistamientoPersonalComfasubDTO
    {

        public int EvaluacionAlistamientoPersonalId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? FechaEvaluacion { get; set; }
        public string? NombresPersonal { get; set; }
        public string? DNIPersonal { get; set; }
        public string? CIPPersonal { get; set; }
        public string? CodigoCargo { get; set; }
        public string? CodigoGradoPersonalMilitarEsperado { get; set; }
        public string? CodigoEspecialidadGenericaPersonalEsperado { get; set; }
        public string? CodigoGradoPersonalMilitarActual { get; set; }
        public string? CodigoEspecialidadGenericaActual { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; }
        public string? DestaqueDependencia { get; set; }
        public string? FechaInicioDestaque { get; set; }
        public string? FechaFinDestaque { get; set; }
        public string? TiempoEmbarque { get; set; }
        public string? DespliegeComisionExtranjero { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescCargo { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescGradoPersonalMilitarActual { get; set; }
        public string? DescEspecialidadGenericaPersonalActual { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
