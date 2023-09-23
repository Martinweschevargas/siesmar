using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfoe
{
    public partial class AlistamientoRepuestoCriticoComfoeDTO
    {

        public int AlistamientoRepuestoCriticoComfoeId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoRepuestoCritico { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaRepuestoCritico { get; set; }
        public string? DescSubsistemaRepuestoCritico { get; set; }
        public string? Equipo { get; set; }
        public string? Repuesto { get; set; }
        public string? Existente { get; set; }
        public string? Necesario { get; set; }
        public string? CoeficientePonderacion { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
