using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuavinav
{
    public partial class AlistamientoRepuestoCriticoComfuavinavDTO
    {

        public int? AlistamientoRepuestoCriticoComfuavinavId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoRepuestoCritico { get; set; }
        public int? CargaId { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaRespuestoCritico { get; set; }
        public string? DescSubsistemaRepuestoCritico { get; set; }
        public string? Equipo { get; set; }
        public string? Repuesto { get; set; }
        public string? Existente { get; set; }
        public string? Necesario { get; set; }
        public string? CoeficientePonderacion { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
