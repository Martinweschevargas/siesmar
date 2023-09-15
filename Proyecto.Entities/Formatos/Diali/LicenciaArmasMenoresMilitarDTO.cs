using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diali
{
    public partial class LicenciaArmasMenoresMilitarDTO
    {
        public int LicenciaArmaMenorId { get; set; }
        public string? CodigoDocumentoArmaMenor { get; set; }
        public string? SolDocumentoArmaMenor { get; set; }
        public string? FechaSolicitudLicArmaMenor { get; set; }
        public string? CodigoTramiteArmaMenor { get; set; }    
        public string? CodigoSituacionPersonalSolicitante { get; set; }
        public string? CondicionAprobLicArmaMenor { get; set; }
        public string? FechaOtorgamientoLicArmaMenor { get; set; }
        public string? NroLicenciaArmaMenor { get; set; }
        public int? CargaId { get; set; }

        public string? DescTramiteArmaMenor { get; set; }
        public string? DescSituacionPersonalSol { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
