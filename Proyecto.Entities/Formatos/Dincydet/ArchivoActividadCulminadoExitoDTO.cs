using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dincydet
{
    public partial class ArchivoActividadCulminadoExitoDTO
    {
        public int ArchivoActividadCulminadoExitoId { get; set; }
        public string? DenominacionActividadCulminado { get; set; }
        public string? TipoTrabajoActividadCulminado { get; set; }
        public string? EtapaActividadCulminado { get; set; }
        public decimal? FinanciamientoTPActividadCulminado { get; set; }
        public decimal? FinanciamientoRDRActividadCulminado { get; set; }
        public decimal? FinanciamientoTransferenciaActividadCulminado { get; set; }
        public string? CodigoAreaCT { get; set; }

        public string? DescAreaCT { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
