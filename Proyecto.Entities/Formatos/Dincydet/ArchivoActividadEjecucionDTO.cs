using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dincydet
{
    public partial class ArchivoActividadEjecucionDTO
    {
        public int ArchivoActividadEjecucionId { get; set; }
        public string? DenominacionActividadEjecucion { get; set; }
        public string? TipoTrabajoActividadEjecucion { get; set; }
        public int? SituacionActualActividadEjecucion { get; set; }
        public decimal? FinanciamientoTPActividadEjecucion { get; set; }
        public decimal? FinanciamientoRDRActividadEjecucion { get; set; }
        public decimal? FinanciamientoTransferenciaActividadEjecucion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
