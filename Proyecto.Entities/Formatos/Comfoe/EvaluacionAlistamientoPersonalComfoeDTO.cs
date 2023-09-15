using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfoe
{
    public partial class EvaluacionAlistamientoPersonalComfoeDTO
    {

        public int EvaluacionAlistamientoPersonalId { get; set; }
        public String? CodigoUnidadNaval { get; set; }
        public string? FechaEvaluacion { get; set; }
        public String? DNIPersonal { get; set; }
        public String? CIPPersonal { get; set; }
        public String? CodigoCargo { get; set; }
        public String? CodigoGradoPersonalMilitar { get; set; }
        public decimal? GradoJerarquico { get; set; }
        public decimal? ServicioExperiencia { get; set; }
        public decimal? EspecializacionProfesional { get; set; }
        public decimal? CursoProfesionalRequerido { get; set; } 

        public string? DescUnidadNaval { get; set; }
        public string? DescCargo { get; set; }
        public string? DescGrado { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
