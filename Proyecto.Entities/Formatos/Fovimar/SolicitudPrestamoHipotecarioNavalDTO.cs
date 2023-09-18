using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Fovimar
{
    public partial class SolicitudPrestamoHipotecarioNavalDTO
    {

        public int? SolicitudPrestamoHipotecarioNavalId { get; set; }
        public string? DNIPersonalNaval { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoSituacionPersonalNaval { get; set; }
        public string? Prestario { get; set; }
        public decimal? MontoSolicitado { get; set; }
        public string? CodigoMoneda { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? AprobacionSolicitud { get; set; }
        public string? FechaAprobacion { get; set; }
        public string? FechaDesembolso { get; set; }
        public int? NroCuota { get; set; }
        public string? CodigoModalidadPrestamo { get; set; }
        public string? CodigoFinalidadPrestamo { get; set; }
        public string? CodigoEntidadFinanciera { get; set; }
        public decimal? RentabilidadFinanciera { get; set; }
        public string? CodigoProyectoFovimar { get; set; }
        public string? EstadoSolicitudPrestamo { get; set; }
        public string? GarantiaConstituida { get; set; }
        public int? CargaId { get; set; }
        public string? DescGrado { get; set; }
        public string? DescSituacionPersonalNaval { get; set; }
        public string? DescMoneda { get; set; }
        public string? DescModalidadPrestamo { get; set; }
        public string? DescFinalidadPrestamo { get; set; }
        public string? DescEntidadFinanciera { get; set; }
        public string? DescProyectoFovimar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}