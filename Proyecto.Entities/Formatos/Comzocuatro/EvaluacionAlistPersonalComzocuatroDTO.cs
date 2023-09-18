using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzocuatro
{
    public partial class EvaluacionAlistPersonalComzocuatroDTO
    {

        public int? EvaluacionAlistamientoPersonalId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
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
        public decimal? PuntajeTotalPersonal { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescGradoPersonalMilitarEsperado { get; set; }
        public string? DescEspecialidadGenericaEsperado { get; set; }      
        public string? DescGradoPersonalMilitarActual { get; set; }
        public string? DescEspecialidadGenericaActual { get; set; }


        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
