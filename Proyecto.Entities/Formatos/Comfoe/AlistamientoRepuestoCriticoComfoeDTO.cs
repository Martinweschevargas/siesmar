using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfoe
{
    public partial class AlistamientoRepuestoCriticoComfoeDTO
    {

        public int AlistamientoRepuestoCriticoComfoeId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoRepuestoCritico { get; set; }

        public string? DescUnidadNaval { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
