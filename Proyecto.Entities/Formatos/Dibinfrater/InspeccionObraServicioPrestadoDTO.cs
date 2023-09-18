using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dibinfrater
{
    public partial class InspeccionObraServicioPrestadoDTO
    {

        public int? InspeccionObraServicioPrestadoId { get; set; }
        public string? IdentificacionSolicitud { get; set; }
        public string? NombreObra { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? EstadoSolicitud { get; set; }
        public string? IdentificacionContrato { get; set; }
        public string? CodigoTipoObraServicio { get; set; }
        public string? CodigoTipoProceso { get; set; }
        public decimal? MontoContrato { get; set; }
        public string? FechaInicioObraServicio { get; set; }
        public string? FechaTerminoEstimada { get; set; }
        public int? PorcentajeAvanceFisico { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescTipoObraServicio { get; set; }
        public string? DescTipoProceso { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
