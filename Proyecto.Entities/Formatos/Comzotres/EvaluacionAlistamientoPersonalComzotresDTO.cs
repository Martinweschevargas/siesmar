using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzotres
{
    public partial class EvaluacionAlistamientoPersonalComzotresDTO
    {
        public int? EvaluacionAlistamientoPersonalId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? FechaEvaluacion { get; set; }
        public string? DNIPersonal { get; set; }
        public string? CIPPersonal { get; set; }
        public string? CodigoCargo { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; }
        public decimal? PuntajeTotalPersonal { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescCargo { get; set; }
        public string? DescGrado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
