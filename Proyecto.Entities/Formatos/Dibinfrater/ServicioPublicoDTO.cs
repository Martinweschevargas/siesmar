using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dibinfrater
{
    public partial class ServicioPublicoDTO
    {

        public int? ServicioPublicoId { get; set; }
        public int? AnioPagoServicio { get; set; }
        public string? NumericoMes { get; set; }
        public string? CodigoFuenteFinanciamiento { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoTipoServicioPublico { get; set; }
        public int? SuministroUnico { get; set; }
        public decimal? AsignacionMensual { get; set; }
        public decimal? ConsumoMensual { get; set; }
        public string? ConsumoUnidadMedida { get; set; }
        public string? DescMes { get; set; }
        public string? DescFuenteFinanciamiento { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescTipoServicioPublico { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
