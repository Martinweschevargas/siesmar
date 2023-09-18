using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuinmar
{
    public partial class AlistamientoRepuestoCriticoComfuinmarDTO
    {

        public int? AlistamientoRepuestoCriticoComfuinmarId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoRepuestoCritico { get; set; }
        public int? NroRepuestoExistente { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
