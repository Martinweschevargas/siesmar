using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class AlistamientoRepuestoCriticoComfasubDTO
    {

        public int AlistamientoRepuestoCriticoComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoRepuestoCritico { get; set; }

        public string? DescUnidadNaval { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
