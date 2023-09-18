using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class EmisionFotografiaVideoDTO
    {

        public int? EmisionFotografiaVideoId { get; set; }
        public string? FechaEmisionFotoVideo { get; set; }
        public string? TipoCosto { get; set; }
        public string? CodigoProductoDimar { get; set; }
        public int? Cantidad { get; set; }
        public decimal? MontoRecaudado { get; set; }


        public string? DescProductoDimar { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
