using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class ConsolidadoComisionCeremoniaDTO
    {

        public int? ConsolidadoComisionCeremoniaId { get; set; }
        public string? FechaActividad { get; set; }
        public string? Actividad { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }
        public decimal? Costo { get; set; }

        public string? DescUnidadMedida { get; set; }
        public string? DescPublicoObjetivo { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
