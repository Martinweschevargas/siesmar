using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Fovimar
{
    public partial class PrestamoHipotecarioNavalDTO
    {

        public int? PrestamoHipotecarioNavalId { get; set; }
        public string? DNIPersonalNaval { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoSituacionPersonalNaval { get; set; }
        public decimal? MontoPrestadoOtorgado { get; set; }
        public string? CodigoMoneda { get; set; }
        public int? NroCuota { get; set; }
        public string? CodigoModalidadPrestamo { get; set; }
        public string? CodigoFinalidadPrestamo { get; set; }
        public string? CodigoEntidadFinanciera { get; set; }
        public decimal? RentabilidadFinanciera { get; set; }
        public string? CodigoProyectoFovimar { get; set; }
        public string? GarantiaConstituida { get; set; }
        public int? CuotaPagada { get; set; }
        public string? EstadoDeuda { get; set; }
        public decimal? MontoMorosidad { get; set; }
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