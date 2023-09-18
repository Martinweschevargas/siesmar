using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class CampañaComunicacionalDTO
    {

        public int? CampaniaComunicacionalId { get; set; }
        public string? CodigoProductoDimar { get; set; }
        public string? FechaPublicacion { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? PlataformaMedioPublicacion { get; set; }
        public string? CodigoTipoInformacionEmitida { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }
        public int? CantidadProducida { get; set; }
        public string? CodigoFrecuenciaDifusion { get; set; }
        public decimal? CostoCampania { get; set; }


        public string? DescProductoDimar { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescTipoInformacionEmitida { get; set; }
        public string? DescPublicoObjetivo { get; set; }
        public string? DescFrecuenciaDifusion { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
