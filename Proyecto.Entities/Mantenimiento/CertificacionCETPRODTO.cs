using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CertificacionCETPRODTO
    {
        public int CertificacionCETPROId { get; set; }
        public string? DescCertificacionCETPRO { get; set; }
        public string? CodigoCertificacionCETPRO { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
