using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirconce
{
    public partial class ConsolidadoRecaudacionAnualContratoDTO
    {

        public int? ConsolidadoRecaudacionAnualContratoId { get; set; }
        public decimal? ConsolidadoRecaudacionAnual { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
