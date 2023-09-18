using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuavinav
{
    public partial class EvaluacionAlistamientoDotacionVueloComfuavinavDTO
    {

        public int? EvaluacionAlistamientoDotacionVueloId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaEvaluacion { get; set; }
        public int? DNIPersonal { get; set; }
        public int? CIPPersonal { get; set; }
        public string? CargoPersonal { get; set; }
        public int? GradoPersonalMilitarEsperado { get; set; }
        public int? EspecialidadGenericaEsperado { get; set; }
        public int? GradoPersonalMilitarActual { get; set; }
        public int? EspecialidadGenericaActual { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; }




        public string? DescUnidadNaval { get; set; }
        public string? DescGradoPersonalMilitarEsperado { get; set; }
        public string? DescEspecialidadGenericaEsperado { get; set; }      
        public string? DescGradoPersonalMilitarActual { get; set; }
        public string? DescEspecialidadGenericaActual { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
