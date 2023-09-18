using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class ServicioSocialBrindadoDTO
    {

        public int? ServicioSocialBrindadoId { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? DNIPersonal { get; set; }
        public string? CodigoPersonalSolicitante { get; set; }
        public string? CodigoCondicionSolicitante { get; set; }
        public string? CodigoPersonalBeneficiado { get; set; }
        public string? CodigoTipoApoyoSocial { get; set; }
        public string? CodigoTipoAtencion { get; set; }
        public string? CodigoTipoEvaluacionSocial { get; set; }
        public string? OtroTipoApoyo { get; set; }
        public string? ResultadoSolicitud { get; set; }
        public string? FechaResultadoSolicitud { get; set; }


        public string? DescPersonalSolicitante { get; set; }
        public string? DescCondicionSolicitante { get; set; }
        public string? DescPersonalBeneficiado { get; set; }
        public string? DescTipoApoyoSocial { get; set; }
        public string? DescTipoAtencion { get; set; }
        public string? DescTipoEvaluacionSocial { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
