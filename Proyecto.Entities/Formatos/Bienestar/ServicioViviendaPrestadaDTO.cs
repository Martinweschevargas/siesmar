using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class ServicioViviendaPrestadaDTO
    {

        public int? ServicioViviendaPrestadaId { get; set; }
        public string? CIPBeneficiario { get; set; }
        public string? DNIBeneficiario { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? EstadoSolicitud { get; set; }
        public string? CodigoVillaNaval { get; set; }
        public string? CodigoBlockVillaNaval { get; set; }
        public int? NumeroDepartamento { get; set; }
        public string? FechaEntregaVivienda { get; set; }
        public string?  CodigoTipoAsignacionCasaServicio { get; set; }
        public string? PeriodoPermanencia { get; set; }


        public string? DescGrado { get; set; }
        public string? DescVillaNaval { get; set; }
        public string? DescBlockVillaNaval { get; set; }
        public string? DescTipoAsignacionCasaServicio { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
