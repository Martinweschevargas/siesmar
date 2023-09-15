using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class SolicitudPrestamoConvenioDTO
    {

        public int? SolicitudPrestamoConvenioId { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? DNIBeneficiario { get; set; }
        public string? CIPBeneficiario { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public int? AnioServicio { get; set; }
        public string? ResultadoSolicitud { get; set; }
        public string? CodigoEntidadFinanciera { get; set; }
        public string? CodigoTipoPrestamoConvenio { get; set; }
        public decimal? TasaInteresPrestamo { get; set; }
        public decimal? ImporteCreditoSoles { get; set; }
        public int? NumeroCuotas { get; set; }


        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEntidadFinanciera { get; set; }
        public string? DescTipoPrestamoConvenio { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
