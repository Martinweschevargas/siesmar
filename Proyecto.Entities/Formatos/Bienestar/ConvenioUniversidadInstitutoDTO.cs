using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class ConvenioUniversidadInstitutoDTO
    {

        public int? ConvenioUniversidadInstitutoId { get; set; }
        public string? FechaSolicitudConvenio { get; set; }
        public string? DNISolicitante { get; set; }
        public string? CodigoPersonalSolicitante { get; set; }
        public string? CodigoCondicionSolicitante { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoPersonalBeneficiado { get; set; }
        public string? NivelEstudioConvenio { get; set; }
        public string? TipoEntidadAcademica { get; set; }
        public string? CodigoInstitucionEducativaSuperior { get; set; }
        public string? ResultadoSolicitud { get; set; }
        public string? FechaResultadoSolicitud { get; set; }


        public string? DescPersonalSolicitante { get; set; }
        public string? DescCondicionSolicitante { get; set; }
        public string? DescGrado { get; set; }
        public string? DescPersonalBeneficiado { get; set; }
        public string? DescInstitucionEducativaSuperior { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
