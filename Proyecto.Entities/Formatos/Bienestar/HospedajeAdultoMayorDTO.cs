using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class HospedajeAdultoMayorDTO
    {

        public int? HospedajeAdultoMayorId { get; set; }
        public string? CodigoPersonalSolicitante { get; set; }
        public string? DNIHospedado { get; set; }
        public string? CodigoCondicionSolicitante { get; set; }
        public string? CodigoPersonalBeneficiado { get; set; }
        public string? CondicionHospedado { get; set; }
        public string? TipoPermanencia { get; set; }
        public string? ResultadoSolicitud { get; set; }
        public string? FechaIngreso { get; set; }
        public string? DescPersonalSolicitante { get; set; }
        public string? DescCondicionSolicitante { get; set; }
        public string? DescPersonalBeneficiado { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
