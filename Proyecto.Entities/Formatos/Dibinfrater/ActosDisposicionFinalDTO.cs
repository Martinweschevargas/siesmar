using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dibinfrater
{
    public partial class ActosDisposicionFinalDTO
    {

        public int? ActoDisposicionFinalId { get; set; }
        public int? AnioActoDisposicionFinal { get; set; }
        public string? NumeroMes { get; set; }
        public string? IdentificacionDisposicionFinal { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? EstadoTramiteSolicitud { get; set; }
        public string? CodigoTipoBien { get; set; }
        public string? CodigoMedidaAdaptadaDisposicionFinal { get; set; }
        public int? CantidadBienes { get; set; }
        public decimal? Monto { get; set; }
        public string? DescMes { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescTipoBien { get; set; }
        public string? DescMedidaAdaptadaDisposicionFinal { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
