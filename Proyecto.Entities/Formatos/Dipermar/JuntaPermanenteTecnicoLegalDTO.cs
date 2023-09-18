using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dipermar
{
    public partial class JuntaPermanenteTecnicoLegalDTO
    {
        public int JuntaPermanenteTecnicoLegalId { get; set; }
        public string? NroDocumentoJunta { get; set; }
        public string? FechaDocumentoJunta { get; set; }
        public string? DocumentacionCompleta { get; set; }
        public string? FechaIngresoDocumento { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SexoPersonal { get; set; }
        public string? CodigoAfeccion { get; set; }
        public string? SituacionActualJunta { get; set; }
        public string? NroActa { get; set; }
        public string? FechaActa { get; set; }
        public string? ConclusionJunta { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescAfeccion { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
