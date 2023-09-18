using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ipecamar
{
    public partial class InvestigacionInstCaracterPrevioDTO
    {
        public int InvestigacionInstCaracterPrevioId { get; set; }
        public string? CodigoTipoInvestigacion { get; set; }
        public string? CodigoMedioInvestigacion { get; set; }
        public string? CodigoMotivoInvestigacion { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? FechaInicioInvestigacion { get; set; }
        public string? FechaTermino { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? SituacionInvestigacion { get; set; }
        public string? CodigoResultadoInvestigacion { get; set; }
        public string? DescTipoInvestigacion { get; set; }
        public string? DescMedioInvestigacion { get; set; }
        public string? DescMotivoInvestigacion { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescResultadoInvestigacion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
