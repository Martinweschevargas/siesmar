using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescuama
{
    public partial class EvaluacionAlistPersonalComescuamaDTO
    {

        public int? EvaluacionAlistamientoPersonalId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? FechaEvaluacion { get; set; }
        public string? DNIPersonal { get; set; }
        public string? CIPPersonal { get; set; }
        public string? CodigoCargo { get; set; }
        public string? CodigoGradoPersonalMilitarEsperado { get; set; }
        public string? CodigoEspecialidadGenericaEsperado { get; set; }
        public string? CodigoGradoPersonalMilitarActual { get; set; }
        public string? CodigoEspecialidadGenericaActual { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; }
        public decimal? TotalPuntaje { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescCargo { get; set; }
        public string? DescGradoPersonalMilitarEsperado { get; set; }
        public string? DescEspecialidadGenericaEsperado { get; set; }      
        public string? DescGradoPersonalMilitarActual { get; set; }
        public string? DescEspecialidadGenericaActual { get; set; }

        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
