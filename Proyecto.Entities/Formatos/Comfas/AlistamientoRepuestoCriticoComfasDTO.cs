using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class AlistamientoRepuestoCriticoComfasDTO
    {

        public int? AlistamientoRepuestoCriticoId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? SistemaRespuestoCriticoId { get; set; }
        public int? SubsistemaRepuestoCriticoId { get; set; }
        public int? EquipoRepuestoCritico { get; set; }
        public int? Repuesto { get; set; }
        public int? RepuestoExistente { get; set; }
        public int? RepuestoNecesario { get; set; }
        public int? CoeficientePonderacion { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaRespuestoCritico { get; set; }
        public string? DescSubsistemaRepuestoCritico { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
