using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class ComisionAudiovisualDTO
    {

        public int? ComisionAudiovisualId { get; set; }
        public string? FechaComisionAudiovisual { get; set; }
        public string? CodigoPersonalComision { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? Motivo { get; set; }
        public string? CodigoComision { get; set; }
        public decimal? Costo { get; set; }

        public string? DescPersonalComision { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescComision { get; set; }

        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
