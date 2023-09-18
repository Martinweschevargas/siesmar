using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Difoserece
{
    public partial class AportFondoRetiroCesacionDTO
    {
        public int AportacionFondoRetiroCesacionId { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? DNIPersonalRetiro { get; set; }
        public string? SexoPersonalRetiro { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoGradoRemunerativo { get; set; }
        public string? CodigoSituacionPersonalNaval { get; set; }
        public string? FechaNacimientoPersonalR { get; set; }
        public string? FechaIngresoPersonalR { get; set; }
        public string? FechaNombramientoPersonalR { get; set; }
        public string? FechaPaseRetiroPersonalR { get; set; }
        public string? FechaReincorporacionPersonalR { get; set; }
        public string? FechaPrimerAportePersonalR { get; set; }
        public string? FechaUltimoAportePersonalR { get; set; }
        public int? NumeroCuotasAportadasPersonalR { get; set; }
        public decimal? AporteMensualUltimoPersonalR { get; set; }
        public string? TipoLiquidacionPersonalR { get; set; }
        public int? DevolucionAportePersonalR { get; set; }
        public string? FechaLiquidacionPersonalR { get; set; }
        public string? CodigoCausalLiquidacion { get; set; }
        public int? CargaId { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescGradoRemunerativo { get; set; }
        public string? DescSituacionPersonalNaval { get; set; }
        public string? DescCausalLiquidacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
