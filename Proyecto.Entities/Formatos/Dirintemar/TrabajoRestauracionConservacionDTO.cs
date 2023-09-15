using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class TrabajoRestauracionConservacionDTO
    {
        public int TrabajoRestauracionId { get; set; }
        public int? TrabajoRealizadoBienHistoricoId { get; set; }
        public int? NroTrabajo { get; set; }
        public int? NroPiezaTratada { get; set; }
        public int? NroPersonaRealizanTrabajo { get; set; }
        public string? FechaInicioTrabajoRestConserv { get; set; }
        public string? FechaTerminoTrabajoRestConserv { get; set; }
        public string? EncargadoTrabajoRestConserv { get; set; }
        public string? DescripcionTrabajoRealizado { get; set; }
        public decimal? InversionTrabajoRestConserv { get; set; }
        public string? DescTrabajoRealizadoBienHistorico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
