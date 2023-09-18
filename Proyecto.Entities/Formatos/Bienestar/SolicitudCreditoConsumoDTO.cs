using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class SolicitudCreditoConsumoDTO
    {

        public int? SolicitudCreditoConsumoId { get; set; }
        public string? FechaSolicitudCredito { get; set; }
        public string? DNISolicitante { get; set; }
        public string? CIPSolicitante { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public int? AnioServicio { get; set; }
        public string? ResultadoSolicitud { get; set; }
        public string? CodigoEntidadFinanciera { get; set; }
        public int? NumeroCuotas { get; set; }
        public decimal? ImporteCredito { get; set; }
        public decimal? TasaInteresCredito { get; set; }


        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEntidadFinanciera { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
