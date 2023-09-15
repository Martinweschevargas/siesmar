using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuavinav
{
    public partial class AlistamientoMunicionComfuavinavDTO
    {

        public int? AlistamientoMunicionComfuavinavId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoMunicion { get; set; }
        public int? CargaId { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? Equipo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
