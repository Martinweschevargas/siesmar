using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class MillaNavegacionUnidadComfasDTO
    {

        public int? MillaNavegacionUnidadComfasId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? MesId { get; set; }
        public decimal? Millas { get; set; }
        public string? HorasMinutos { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescMes { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
