using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class EvaluacionAlistamientoPersonalComestreDTO
    {

        public int? EvaluacionAlistamientoPersonalComestreId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaEvaluacion { get; set; }
        public int? DNIPersonal { get; set; }
        public int? CIPPersonal { get; set; }
        public string? CargoPersonal { get; set; }
        public int? GradoPersonalMilitarEsperado { get; set; }
        public int? EspecialidadGenericaPersonalEsperado { get; set; }
        public int? GradoPersonalMilitarActual { get; set; }
        public int? EspecialidadGenericaPersonalActual { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; }
        public decimal? TotalPuntaje { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescGradoEsperado { get; set; }
        public string? DescEspecialidadGenericaPersonalEsperado { get; set; }
        public string? DescGradoActual { get; set; }
        public string? DescEspecialidadGenericaPersonalActual { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}