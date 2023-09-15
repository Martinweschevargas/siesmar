using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ipecamar
{
    public partial class AsuntosDisciplinariosDTO
    {
        public int AsuntoDisciplinarioId { get; set; }
        public string? UUDDConvocante { get; set; }
        public string? CodigoMotivoInvestigacion { get; set; }
        public string? CodigoDetalleInfraccion { get; set; }
        public string? FechaInicioInvestigacion { get; set; }
        public string? FechaTerminoInvestigacion { get; set; }
        public int? PlazoInvestigacion { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SituacionInvestigacion { get; set; }
        public string? CodigoResultadoInvestigacion { get; set; }
        public string? DescMotivoInvestigacion { get; set; }
        public string? DescDetalleInfraccion { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescTipoPersonalMilitar { get; set; } 
        public string? DescGrado { get; set; }
        public string? DescResultadoInvestigacion { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
